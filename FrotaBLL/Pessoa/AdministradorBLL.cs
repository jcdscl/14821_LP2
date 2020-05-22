//-------------------------------------------------------------------------------------------
// <copyright file="AdministradorBLL.cs" company="IPCA - Instituto Politecnico do Cavado e do Ave">
// </copyright>
// <description>Gestao Frota Veiculos</description>
// <date>11/04/2020</date>
// <author>Jose Loureiro</author>
// <email>a14821@alunos.ipca.pt</email>
//-------------------------------------------------------------------------------------------
using FrotaBO;
using FrotaDAL;

namespace FrotaBLL
{
    /// <summary>
    /// Nesta classe estao definidas as regras de negocio
    /// </summary>
    public class AdministradorBLL
    {
        /// <summary>
        /// Este programa so' podera' ter 2 administradores no ativo
        /// </summary>
        private const int maxAdministradores = 2;

        /// <summary>
        /// Este metodo verifica se e' possivel registar mais administradores
        /// </summary>
        /// <returns>true -> se estiverem 2 ou menos admin no ativo
        ///          false-> se o max de registos for atingido
        /// </returns>
        public static bool VerificaMaximoAdministradorBLL()
        {
            return (DadosAdministradores.DevolveQuantidadeAdministrador() < maxAdministradores);
        }

        /// <summary>
        /// Lista os dados dos Administradores guardados
        /// </summary>
        /// <returns></returns>
        public static bool ListagemAdministradoresBLL(AdministradorBO a)
        {
            if (VerificaNivelDeAcessoAdministradorBLL(a))
            {
                System.Console.WriteLine("\n# Listagem Administradores");
                DadosAdministradores.ListagemAdministradores();
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Metodo que devolve um id valido para atribuir ao novo Administrador
        /// </summary>
        /// <returns> novo id = 1 + nr de registos ate' ao momento</returns>
        public static int NovoIdAdministradorBLL()
        {
            return 1 + DadosAdministradores.DevolveIdAdministrador();
        }

        /// <summary>
        /// Metodo que regista um novo Administrador
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool RegistarAdmistradorBLL(AdministradorBO a)
        {
            if (VerificaMaximoAdministradorBLL())
            {
                return DadosAdministradores.RegistarAdmistrador(a);
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Guarda dados para um ficheiro binario
        /// </summary>
        /// <returns></returns>
        public static bool FazerBackupAdministradorBLL()
        {
            return DadosAdministradores.FazerBackupAdministrador();
        }

        /// <summary>
        /// Carregar os dados para memoria
        /// </summary>
        /// <returns></returns>
        public static bool RestaurarBackupAdministradorBLL()
        {
            return DadosAdministradores.RestaurarBackupAdministrador();
        }

        /// <summary>
        /// Verifica se admin esta' no ativo
        /// </summary>
        /// <param name="a"></param>
        /// <returns>true -> esta' no ativo
        ///          false-> nao esta' no ativo
        /// </returns>
        public static bool AdministradorEstaNoAtivoBLL(AdministradorBO a)
        {
            return DadosAdministradores.AdministradorEstaNoAtivo(a);
        }

        /// <summary>
        /// Metodo que verifica se o admin esta' no ativo e se tem o acesso devido
        /// </summary>
        /// <param name="a"></param>
        /// <returns>true -> se estiver no ativo e se tiver acesso
        ///          false-> se estiver no ativo
        ///                  se nao tiver acesso
        /// </returns>
        public static bool VerificaNivelDeAcessoAdministradorBLL(AdministradorBO a)
        {
            int nivelAcesso;

            if (DadosAdministradores.AdministradorEstaNoAtivo(a))
            {
                nivelAcesso = DadosAdministradores.VerificaNivelDeAcesso(a); //devolve nivel de acesso (int)

                //Verifica os niveis de acesso correspondem
                if ((int)PessoaBO.ENUM_NIVEL_ACESSO.Administrador == nivelAcesso)
                {
                    // tem autorizacao
                    return true;
                }
                else
                {
                    // administrador nao tem o acesso
                    return false;
                }
            }
            else
            {
                //Administrador nao esta' no ativo
                return false;
            }
        }
    }
}