//-------------------------------------------------------------------------------------------
// <copyright file="DadosAdministradores.cs" company="IPCA - Instituto Politecnico do Cavado e do Ave">
// </copyright>
// <description>Gestao Frota Veiculos</description>
// <date>11/05/2020</date>
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
    /// Classe responsavel por manipular a estrutura de dados e persistencia de dados
    /// </summary>
    [Serializable]
    public class DadosAdministradores
    {
        /// <summary>
        /// Estrutura de Dados utilizada para armazenar os dados dos Administradores
        /// </summary>
        private static List<AdministradorBO> ArquivoAdministradores;

        /// <summary>
        /// inicializacao da lista
        /// </summary>
        static DadosAdministradores()
        {
            ArquivoAdministradores = new List<AdministradorBO>();
        }

        /// <summary>
        /// metodo que devolve a quantidade de Administradores no ativo
        /// </summary>
        /// <returns></returns>
        public static int DevolveQuantidadeAdministrador()
        {
            int count = 0;

            foreach (AdministradorBO registo in ArquivoAdministradores)
            {
                if (registo.EmAtividade == true)
                {
                    count++;
                }
            }
            return count;
        }

        /// <summary>
        /// Listagem dos administradores no sistema
        /// </summary>
        public static void ListagemAdministradores()
        {
            foreach (AdministradorBO registo in ArquivoAdministradores)
            {
                Console.WriteLine("ID:           [" + registo.IdAdministrador + "]\n"
                                + "Nome:         [" + registo.NomeCompleto + "]\n"
                                + "Acesso:       [" + registo.NivelAcesso + "]\n"
                                + "Em atividade: [" + registo.EmAtividade + "]\n"
                                + "NIF:          [" + registo.NIF1 + "]\n"
                                + "Data Nascim.: [" + registo.DataNasciemnto + "]\n"
                                + "Contacto:     [" + registo.NumeroTelemovel + "]\n"
                                + "Email:        [" + registo.Email + "]\n-----------------------------------------------");
            }
        }

        /// <summary>
        /// Devolve nr de registos ate' ao momento
        /// </summary>
        /// <returns>int -> nr de registos</returns>
        public static int DevolveIdAdministrador()
        {
            return ArquivoAdministradores.Count();
        }

        /// <summary>
        /// Adiciona um admin no dicionario
        /// </summary>
        /// <param name="a"></param>
        /// <returns>true ->se adicionar
        ///          false->se já existir
        /// </returns>
        public static bool RegistarAdmistrador(AdministradorBO a)
        {
            if (ArquivoAdministradores.Contains(a)) return false;
            ArquivoAdministradores.Add(a);
            return true;
        }

        /// <summary>
        /// Metodo que devolve o nivel de acesso de um dado admin
        /// </summary>
        /// <param name="a"></param>
        /// <returns>int -> nivel de acesso</returns>
        public static int VerificaNivelDeAcesso(AdministradorBO a)
        {
            return (int)a.NivelAcesso;
        }

        /// <summary>
        /// Verifica se um dado admin esta' em atividade
        /// </summary>
        /// <param name="a"></param>
        ///
        /// <returns>true -> esta' no ativo
        ///          false-> se nao existe ou nao esta' no ativo
        /// </returns>
        public static bool AdministradorEstaNoAtivo(AdministradorBO a)
        {
            if (ArquivoAdministradores.Contains(a))
            {
                return a.EmAtividade;
            }
            else return false;
        }

        /// <summary>
        /// Copiar dados dos administradores para um ficheiro binario
        /// </summary>
        /// <returns></returns>
        public static bool FazerBackupAdministrador()
        {
            string ficheiroBackup = @"c:\temp\backupAdmin.bin";

            Stream f = File.Open(ficheiroBackup, FileMode.Create, FileAccess.ReadWrite);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(f, ArquivoAdministradores);
            f.Flush();
            f.Close();
            f.Dispose();
            return true;
        }

        /// <summary>
        /// Copia para memoria os dados de um ficheiro binario
        /// </summary>
        /// <returns></returns>
        public static bool RestaurarBackupAdministrador()
        {
            string ficheiroBackup = @"c:\temp\backupAdmin.bin";

            Stream f = File.Open(ficheiroBackup, FileMode.Open, FileAccess.Read);
            BinaryFormatter bf = new BinaryFormatter();
            ArquivoAdministradores = (List<AdministradorBO>)bf.Deserialize(f);
            f.Close();

            return true;
        }
    }
}