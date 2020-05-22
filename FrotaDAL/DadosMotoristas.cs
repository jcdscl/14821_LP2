//-------------------------------------------------------------------------------------------
// <copyright file="DadosMotoristas.cs" company="IPCA - Instituto Politecnico do Cavado e do Ave">
// </copyright>
// <description>Gestao Frota Veiculos</description>
// <date>11/05/2020</date>
// <author>Jose Loureiro</author>
// <email>a14821@alunos.ipca.pt</email>
//-------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using FrotaBO;

namespace FrotaDAL
{
    /// <summary>
    /// classe responsavel por manipular os Dados relativos aos motoristas
    /// </summary>
    [Serializable]
    public class DadosMotoristas
    {
        /// <summary>
        /// Estrutura utilizada para guardar as informacoes
        /// </summary>
        private static Dictionary<int, MotoristaBO> ArquivoMotoristas;

        /// <summary>
        /// Novo Dicionario de motoristas: chave -> id int  -> valor: objeto Motorista
        /// </summary>
        static DadosMotoristas()
        {
            ArquivoMotoristas = new Dictionary<int, MotoristaBO>();
        }

        /// <summary>
        /// metodo regista novo motorista
        /// </summary>
        /// <param name="m"></param>
        public static void RegistaMotorista(MotoristaBO m)
        {
            ArquivoMotoristas.Add(m.IdColaborador, m);
        }

        /// <summary>
        /// "Remover" motorista = Mudar atividade para false
        /// </summary>
        /// <param name="idMotorista"></param>
        public static void DispensaMotorista(int idMotorista)
        {
            ArquivoMotoristas[idMotorista].EmAtividade = false;
        }

        /// <summary>
        /// Verifica se o motorista existe no dicionario (procura pela chave)
        /// </summary>
        /// <param name="idMotorista"></param>
        /// <returns>true -> se existir o id
        ///          false-> se nao exitir o id no sistema
        /// </returns>
        public static bool VerificaSeExisteMotorista(int idMotorista)
        {
            return ArquivoMotoristas.ContainsKey(idMotorista);
        }

        /// <summary>
        /// Listagem do motoristas registados no sistema
        /// </summary>
        /// <returns></returns>
        public static void ListagemMotoristas()
        {
            foreach (KeyValuePair<int, MotoristaBO> registo in ArquivoMotoristas)
            {
                Console.WriteLine("ID:           [" + registo.Key + "]\n"
                                + "Nome:         [" + registo.Value.NomeCompleto + "]\n"
                                + "Acesso:       [" + registo.Value.NivelAcesso + "]\n"
                                + "Em atividade: [" + registo.Value.EmAtividade + "]\n"
                                + "NIF:          [" + registo.Value.NIF1 + "]\n"
                                + "Data Nascim.: [" + registo.Value.DataNasciemnto + "]\n"
                                + "Contacto:     [" + registo.Value.NumeroTelemovel + "]\n"
                                + "Email:        [" + registo.Value.Email + "]\n" +
                                "-----------------------------------------------");
            }
        }

        /// <summary>
        /// Metodo que retorna o nivel de acesso de um dado motorista
        /// </summary>
        /// <param name="idMotorista"></param>
        /// <returns>int -> nivel de acesso</returns>
        public static int VerificaNivelDeAcesso(int idMotorista)
        {
            return (int)ArquivoMotoristas[idMotorista].NivelAcesso;
        }

        /// <summary>
        /// Verifica se um dado motorista esta' em atividade
        /// </summary>
        /// <param name="idMotorista"></param>
        ///
        /// <returns>true -> esta' no ativo
        ///          false-> se nao esta' no ativo
        /// </returns>
        public static bool MotoristaEstaNoAtivo(int idMotorista)
        {
            return ArquivoMotoristas[idMotorista].EmAtividade;
        }

        public static int DevolveIdMotorista()
        {
            return ArquivoMotoristas.Count;
        }

        /// <summary>
        /// Metodo que retorna a data de validade da carta do motorista
        /// </summary>
        /// <param name="idMotorista"></param>
        /// <returns>retorna data de validade
        /// </returns>
        public static DateTime DevolveValidade(int idMotorista)
        {
            return ArquivoMotoristas[idMotorista].Validade;
        }

        /// <summary>
        /// Copiar dados dos motoristas para um ficheiro binario
        /// </summary>
        /// <returns></returns>
        public static string FazerBackupMotoristas()
        {
            string ficheiroBackup = @"c:\temp\backupMotoristas.bin";

            Stream f = File.Open(ficheiroBackup, FileMode.Create, FileAccess.ReadWrite);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(f, ArquivoMotoristas);
            f.Flush();
            f.Close();
            f.Dispose();
            return ficheiroBackup;
        }

        /// <summary>
        /// Copia para memoria os dados de um ficheiro binario
        /// </summary>
        /// <returns></returns>
        public static string RestaurarBackupMotoristas()
        {
            string ficheiroBackup = @"c:\temp\backupMotoristas.bin";

            Stream f = File.Open(ficheiroBackup, FileMode.Open, FileAccess.Read);
            BinaryFormatter bf = new BinaryFormatter();
            ArquivoMotoristas = (Dictionary<int, MotoristaBO>)bf.Deserialize(f);
            f.Close();

            return ficheiroBackup;
        }
    }
}