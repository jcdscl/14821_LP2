//-------------------------------------------------------------------------------------------
// <copyright file="DadosVeiculos.cs" company="IPCA - Instituto Politecnico do Cavado e do Ave">
// </copyright>
// <description>Gestao Frota Veiculos</description>
// <date>14/05/2020</date>
// <author>Jose Loureiro</author>
// <email>a14821@alunos.ipca.pt</email>
//-------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using FrotaBO;
using Newtonsoft.Json;

namespace FrotaDAL
{
    /// <summary>
    /// Classe responsavel por manipular a estrutura de dados e persistencia de dados
    /// </summary>
    [Serializable]
    public class DadosVeiculos
    {
        /// <summary>
        /// Dicionario de veiculos, static -> para existir apenas uma instancia
        /// chave = string (matricula) ; valor = (veiculo)
        /// </summary>
        private static Dictionary<string, VeiculoBO> FrotaVeiculos;

        /// <summary>
        /// Dicionario das atribuicoes dos veiculos.
        /// chave = string (matricula); valor = id do motorista
        /// </summary>
        private static Dictionary<DateTime, AtribuicaoVeiculoBO> ArquivoAtribuicoes;

        /// <summary>
        /// Criar FrotaVeiculos e ArquivoAtribuicoes
        /// </summary>
        static DadosVeiculos()
        {
            FrotaVeiculos = new Dictionary<string, VeiculoBO>();
            ArquivoAtribuicoes = new Dictionary<DateTime, AtribuicaoVeiculoBO>();
        }

        #region FrotaVeiculos

        /// <summary>
        /// metodo responsavel por devolver o estado do veiculo (int)
        /// </summary>
        /// <param name="matricula"></param>
        /// <returns>estado do veiculo (int)</returns>
        public static int DevolveEstadoVeiculo(string matricula)
        {
            return (int)DadosVeiculos.FrotaVeiculos[matricula].EstadoVeiculo;
        }

        /// <summary>
        /// metodo que recebe uma matricula e verifica se existe no dicionario
        /// </summary>
        /// <param name="m"></param>
        /// <returns>true -> se existir a matricula
        ///          false-> se nao exitir a matricula no sistema
        /// </returns>
        public static bool VerificaSeExiste(string m)
        {
            return FrotaVeiculos.ContainsKey(m);
        }

        /// <summary>
        /// Metodo que regista um veiculo
        /// </summary>
        /// <param name="v"></param>
        public static void RegistaVeiculo(VeiculoBO v)
        {
            FrotaVeiculos.Add(v.Matricula, v);
        }

        /// <summary>
        /// Dispensar veiculo
        /// </summary>
        /// <param name="matricula"></param>
        public static void RemoverVeiculo(string matricula)
        {
            FrotaVeiculos[matricula].EstadoVeiculo = VeiculoBO.ENUM_ESTADO_VEICULO.indisponivel;
        }

        /// <summary>
        /// neste metodo é possivel listar todo o dicionario
        /// </summary>
        public static void ListarFrotaVeiculos()
        {
            foreach (KeyValuePair<string, VeiculoBO> registo in FrotaVeiculos)
            {
                Console.WriteLine("Matricula:  [" + registo.Key + "]\n"
                                + "Estado:     [" + registo.Value.EstadoVeiculo + "]\n"
                                + "Fabricante: [" + registo.Value.Fabricante + "]\n"
                                + "Cor:        [" + registo.Value.Cor + "]\n" +
                                "-----------------------------------------------");
            }
        }

        /// <summary>
        /// Copiar dados dos veiculos para um ficheiro binario
        /// </summary>
        /// <returns></returns>
        public static string FazerBackupFrota()
        {
            string ficheiroBackup = @"c:\temp\backupFrota.bin";

            Stream f = File.Open(ficheiroBackup, FileMode.Create, FileAccess.ReadWrite);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(f, FrotaVeiculos);
            f.Flush();
            f.Close();
            f.Dispose();
            return ficheiroBackup;
        }

        /// <summary>
        /// Copia para memoria os dados de um ficheiro binario
        /// </summary>
        /// <returns></returns>
        public static string RestaurarBackupFrota()
        {
            string ficheiroBackup = @"c:\temp\backupFrota.bin";

            Stream f = File.Open(ficheiroBackup, FileMode.Open, FileAccess.Read);
            BinaryFormatter bf = new BinaryFormatter();
            FrotaVeiculos = (Dictionary<string, VeiculoBO>)bf.Deserialize(f);
            f.Close();

            return ficheiroBackup;
        }

        #endregion FrotaVeiculos

        #region ArquivoAtribuicoes

        /// <summary>
        /// Adicionar um novo pedido no arquivo
        /// </summary>
        /// <param name="data"></param>
        /// <param name="pedido"></param>
        public static void NovaAtribuicao(DateTime data, AtribuicaoVeiculoBO pedido)
        {
            ArquivoAtribuicoes.Add(data, pedido);
        }

        /// <summary>
        /// verifica se um motorista tem algum veiculo atribuido
        /// </summary>
        /// <param name="idMotorista"></param>
        /// <returns>true-> se tem dependencia
        ///          false-> nao tem dependencia
        /// </returns>
        public static bool TemVeiculoAtribuido(int idMotorista)
        {
            foreach (KeyValuePair<DateTime, AtribuicaoVeiculoBO> registo in ArquivoAtribuicoes)
            {
                if (registo.Value.IdColaborador == idMotorista) //existe
                {
                    if ((int)registo.Value.EstadoAtribuicao <= 1) // 0 - revistaAprovada 1 - faltaRever
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// verifica se um veiculo tem algum motorista atribuido
        /// </summary>
        /// <param name="matricula"></param>
        /// <returns>true-> se tem dependencia
        ///          false-> nao tem dependencia
        /// </returns>
        public static bool TemMotoristaAtribuido(string matricula)
        {
            foreach (KeyValuePair<DateTime, AtribuicaoVeiculoBO> registo in ArquivoAtribuicoes)
            {
                if (registo.Value.MatriculaVeiculo == matricula)
                {
                    if ((int)registo.Value.EstadoAtribuicao <= 1) // 0 - revistaAprovada 1 - faltaRever
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// devolve id para nova atribuicao
        /// </summary>
        /// <returns></returns>
        public static int DevolveIdAtribuicao()
        {
            return ArquivoAtribuicoes.Count;
        }

        /// <summary>
        /// Listar todas as atribuicoes
        /// </summary>
        public static void ListarAtribuicoes()
        {
            foreach (KeyValuePair<DateTime, AtribuicaoVeiculoBO> registo in ArquivoAtribuicoes)
            {
                Console.WriteLine("Data:         [" + registo.Key.ToString("g") + "]\n"
                                + "Id:           [" + registo.Value.IdReserva + "]\n"
                                + "Matricula:    [" + registo.Value.MatriculaVeiculo + "]\n"
                                + "Id Motorista: [" + registo.Value.IdColaborador + "]\n"
                                + "Estado:       [" + registo.Value.EstadoAtribuicao + "]\n"
                                + "-----------------------------------------------");
            }
        }

        /// <summary>
        /// metodo que liberta o veiculo caso o motorista seja removido
        /// </summary>
        /// <param name="idMotorista"></param>
        public static void LibertarVeiculoAtribuicoes(int idMotorista)
        {
            foreach (KeyValuePair<DateTime, AtribuicaoVeiculoBO> registo in ArquivoAtribuicoes)
            {
                if (registo.Value.IdColaborador == idMotorista)
                {
                    registo.Value.EstadoAtribuicao = AtribuicaoVeiculoBO.ENUM_ESTADO_ATRIBUICAO.invalida;
                    DadosVeiculos.FrotaVeiculos[registo.Value.MatriculaVeiculo].EstadoVeiculo = VeiculoBO.ENUM_ESTADO_VEICULO.disponivel;
                }
            }
        }

        /// <summary>
        /// metodo que coloca atribuicao invalida e veiculo indisponivel
        /// </summary>
        /// <param name="matricula"></param>
        public static void LibertarVeiculoAtribuicoesII(string matricula)
        {
            foreach (KeyValuePair<DateTime, AtribuicaoVeiculoBO> registo in ArquivoAtribuicoes)
            {
                if (registo.Value.MatriculaVeiculo == matricula)
                {
                    registo.Value.EstadoAtribuicao = AtribuicaoVeiculoBO.ENUM_ESTADO_ATRIBUICAO.invalida;
                    DadosVeiculos.FrotaVeiculos[registo.Value.MatriculaVeiculo].EstadoVeiculo = VeiculoBO.ENUM_ESTADO_VEICULO.indisponivel;
                }
            }
        }

        /// <summary>
        /// consultar atribuicao pelo id do motorista
        /// </summary>
        /// <param name="id"></param>
        public static void ConsultarAtribuicao(int id)
        {
            foreach (KeyValuePair<DateTime, AtribuicaoVeiculoBO> registo in ArquivoAtribuicoes)
            {
                if (registo.Value.IdColaborador == id)
                {
                    Console.WriteLine("[{0}]  id: {1}  estado: {2} ", registo.Key.ToString("d"),
                                                                   registo.Value.IdColaborador,
                                                                   registo.Value.EstadoAtribuicao);
                }
            }
        }

        /// <summary>
        /// rever atribuicao dos veiculos
        /// </summary>
        /// <param name="id"></param>
        /// <param name="opcao"> 0-> reprovada   1-> aprovada</param>
        public static void ReverAtribuicao(int id, int opcao)
        {
            foreach (KeyValuePair<DateTime, AtribuicaoVeiculoBO> registo in ArquivoAtribuicoes) //procurar pelo id
            {
                if (registo.Value.IdColaborador == id)      //se encontrado
                {
                    if (opcao == 1)
                    {
                        registo.Value.EstadoAtribuicao = AtribuicaoVeiculoBO.ENUM_ESTADO_ATRIBUICAO.revistoAprovada;
                        FrotaVeiculos[registo.Value.MatriculaVeiculo].EstadoVeiculo = VeiculoBO.ENUM_ESTADO_VEICULO.atribuido;
                    }
                    else
                    {
                        registo.Value.EstadoAtribuicao = AtribuicaoVeiculoBO.ENUM_ESTADO_ATRIBUICAO.revistoReprovada;
                    }
                }
            }
            ConsultarAtribuicao(id);
        }

        public static int DelvolveIdReserva()
        {
            return ArquivoAtribuicoes.Count();
        }

        /// <summary>
        /// Copiar dados das atribicoes de veiculos para um ficheiro json
        /// </summary>
        /// <returns></returns>
        public static string FazerBackupAtribuicoes()
        {
            string ficheiroBackup = @"c:\temp\backupAtribuicoes.json";

            File.WriteAllText(ficheiroBackup, JsonConvert.SerializeObject(ArquivoAtribuicoes));

            using (StreamWriter f = File.CreateText(ficheiroBackup))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(f, ArquivoAtribuicoes);
            }

            return ficheiroBackup;
        }

        /// <summary>
        /// Copia para memoria os dados de um ficheiro json
        /// </summary>
        /// <returns></returns>
        public static string RestaurarBackupAtribuicoes()
        {
            string ficheiroBackup = @"c:\temp\backupAtribuicoes.json";

            // deserialize JSON directly from a file
            using (StreamReader file = File.OpenText(ficheiroBackup))
            {
                JsonSerializer serializer = new JsonSerializer();
                ArquivoAtribuicoes = (Dictionary<DateTime, AtribuicaoVeiculoBO>)serializer.Deserialize(file, typeof(Dictionary<DateTime, AtribuicaoVeiculoBO>));

                return ficheiroBackup;
            }
        }

        #endregion ArquivoAtribuicoes
    }
}