//-------------------------------------------------------------------------------------------
// <copyright file="DadosRecursosHumanos.cs" company="IPCA - Instituto Politecnico do Cavado e do Ave">
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

namespace FrotaDAL
{
    /// <summary>
    /// Manipulacoa dos dados do RH
    /// </summary>
    [Serializable]
    public class DadosRecursosHumanos
    {
        /// <summary>
        /// Collection escolhida para armazenar os dados do RH
        /// </summary>
        private static Dictionary<int, RecursosHumanosBO> ArquivoRH;

        /// <summary>
        /// Novo Dicionario de RH: chave -> id int  -> valor: RecursosHumanosBO
        /// </summary>
        static DadosRecursosHumanos()
        {
            ArquivoRH = new Dictionary<int, RecursosHumanosBO>();
        }

        /// <summary>
        /// metodo regista novo RH
        /// </summary>
        /// <param name="rh"></param>
        public static void RegistaRH(RecursosHumanosBO rh)
        {
            ArquivoRH.Add(rh.IdColaborador, rh);
        }

        /// <summary>
        /// "Remover" RH = Mudar atividade para false
        /// </summary>
        /// <param name="idRH"></param>

        public static void DispensaRH(int idRH)
        {
            ArquivoRH[idRH].EmAtividade = false;
        }

        /// <summary>
        /// Verifica se o RH existe no dicionario (procura pela chave)
        /// </summary>
        /// <param name="idRH"></param>
        /// <returns>true -> se existir o id
        ///          false-> se nao exitir o id no sistema
        /// </returns>
        public static bool VerificaSeExisteRH(int idRH)
        {
            return ArquivoRH.ContainsKey(idRH);
        }

        /// <summary>
        /// Devolve nr de registos ate' ao momento
        /// </summary>
        /// <returns>int -> nr de registos</returns>
        public static int DevolveIdRH()
        {
            return ArquivoRH.Count();
        }

        /// <summary>
        /// Listagem do RH registados
        /// </summary>
        /// <returns></returns>
        public static void ListagemRH()
        {
            foreach (KeyValuePair<int, RecursosHumanosBO> registo in ArquivoRH)
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
        /// Metodo que retorna o nivel de acesso de um dado RH
        /// </summary>
        /// <param name="idRH"></param>
        /// <returns>int -> nivel de acesso</returns>
        public static int VerificaNivelDeAcesso(int idRH)
        {
            return (int)ArquivoRH[idRH].NivelAcesso;
        }

        /// <summary>
        /// Verifica se um dado RH esta' em atividade
        /// </summary>
        /// <param name="IdRH"></param>
        ///
        /// <returns>true -> esta' no ativo
        ///          false-> nao esta' no ativo
        /// </returns>
        public static bool RHEstaNoAtivo(int IdRH)
        {
            return ArquivoRH[IdRH].EmAtividade;
        }

        /// <summary>
        /// Copiar dados do RH para um ficheiro binario
        /// </summary>
        /// <returns>string -> caminho</returns>
        public static string FazerBackupRH()
        {
            string ficheiroBackup = @"c:\temp\backupRH.bin";

            Stream f = File.Open(ficheiroBackup, FileMode.Create, FileAccess.ReadWrite);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(f, ArquivoRH);
            f.Flush();
            f.Close();
            f.Dispose();
            return ficheiroBackup;
        }

        /// <summary>
        /// Copia para memoria os dados de um ficheiro binario
        /// </summary>
        /// <returns>string -> caminho</returns>
        public static string RestaurarBackupRH()
        {
            string ficheiroBackup = @"c:\temp\backupRH.bin";

            Stream f = File.Open(ficheiroBackup, FileMode.Open, FileAccess.Read);
            BinaryFormatter bf = new BinaryFormatter();
            ArquivoRH = (Dictionary<int, RecursosHumanosBO>)bf.Deserialize(f);
            f.Close();

            return ficheiroBackup;
        }
    }
}