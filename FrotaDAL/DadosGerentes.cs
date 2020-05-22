//-------------------------------------------------------------------------------------------
// <copyright file="DadosGerentes.cs" company="IPCA - Instituto Politecnico do Cavado e do Ave">
// </copyright>
// <description>Gestao Frota Veiculos</description>
// <date>14/05/2020</date>
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
    /// Classe responsável por manipular os dados e a sua persistencia
    /// </summary>
    [Serializable]
    public class DadosGerentes
    {
        /// <summary>
        /// dicionario respondavel por armazenar os dados desta classe
        /// </summary>
        private static Dictionary<int, GerenteBO> ArquivoGerentes;

        /// <summary>
        /// Novo Dicionario de Gerentes: chave -> id int  -> valor: gerenteBO
        /// </summary>
        static DadosGerentes()
        {
            ArquivoGerentes = new Dictionary<int, GerenteBO>();
        }

        /// <summary>
        /// metodo regista novo gerente
        /// </summary>
        /// <param name="g"></param>
        public static void RegistaGerente(GerenteBO g)
        {
            ArquivoGerentes.Add(g.IdGerente, g);
        }

        /// <summary>
        /// "Remover" gerente = Mudar atividade para false
        /// </summary>
        /// <param name="idGerente"></param>
        public static void DispensaGerente(int idGerente)
        {
            ArquivoGerentes[idGerente].EmAtividade = false;
        }

        /// <summary>
        /// Verifica se o gerente existe no dicionario (procura pela chave)
        /// </summary>
        /// <param name="g"></param>
        /// <returns>true -> se existir o id
        ///          false-> se nao exitir o id no sistema
        /// </returns>
        public static bool VerificaSeExisteGerente(int idGerente)
        {
            return ArquivoGerentes.ContainsKey(idGerente);
        }

        /// <summary>
        /// Listagem dos gerentes registados
        /// </summary>
        public static void ListagemGerentes()
        {
            foreach (KeyValuePair<int, GerenteBO> registo in ArquivoGerentes)
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
        /// Metodo que retorna o nivel de acesso de um dado gerente
        /// </summary>
        /// <param name="a"></param>
        /// <returns>int -> nivel de acesso</returns>
        public static int VerificaNivelDeAcesso(int id)
        {
            return (int)ArquivoGerentes[id].NivelAcesso;
        }

        /// <summary>
        /// Verifica se um dado gerente esta' em atividade
        /// </summary>
        /// <param name="a"></param>
        ///
        /// <returns>true -> esta' no ativo
        ///          false-> se nao esta' no ativo
        /// </returns>
        public static bool GerenteEstaNoAtivo(int id)
        {
            return ArquivoGerentes[id].EmAtividade;
        }

        /// <summary>
        /// Devolve nr de registos ate' ao momento
        /// </summary>
        /// <returns>int -> nr de registos</returns>
        public static int DevolveIdGerente()
        {
            return ArquivoGerentes.Count;
        }

        /// <summary>
        /// Copia para memoria os dados de um ficheiro binario
        /// </summary>
        /// <returns></returns>
        public static string RestaurarBackupFrota()
        {
            string ficheiroBackup = @"c:\temp\backupGerentes.bin";

            Stream f = File.Open(ficheiroBackup, FileMode.Open, FileAccess.Read);
            BinaryFormatter bf = new BinaryFormatter();
            ArquivoGerentes = (Dictionary<int, GerenteBO>)bf.Deserialize(f);
            f.Close();

            return ficheiroBackup;
        }

        /// <summary>
        /// Copiar dados dos gerentes para um ficheiro binario
        /// </summary>
        /// <returns></returns>
        public static string FazerBackupFrota()
        {
            string ficheiroBackup = @"c:\temp\backupGerentes.bin";

            Stream f = File.Open(ficheiroBackup, FileMode.Create, FileAccess.ReadWrite);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(f, ArquivoGerentes);
            f.Flush();
            f.Close();
            f.Dispose();
            return ficheiroBackup;
        }
    }
}