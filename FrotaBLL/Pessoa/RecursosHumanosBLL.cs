//-------------------------------------------------------------------------------------------
// <copyright file="RecursosHumanosBLL.cs" company="IPCA - Instituto Politecnico do Cavado e do Ave">
// </copyright>
// <description>Gestao Frota Veiculos</description>
// <date>11/04/2020</date>
// <author>Jose Loureiro</author>
// <email>a14821@alunos.ipca.pt</email>
//-------------------------------------------------------------------------------------------
using System;
using FrotaBO;
using FrotaDAL;

namespace FrotaBLL
{
    /// <summary>
    /// Nesta classe estao definidas as regras de negocio
    /// </summary>
    public class RecursosHumanosBLL
    {
        /// <summary>
        /// Adicionar novo rh no sistema
        /// </summary>
        /// <param name="rh"></param>
        /// <param name="a"></param>
        /// <returns>true -> Registado com sucesso
        ///          false-> se admin nao tiver acesso ou o rh já existe
        /// </returns>
        public static bool RegistaRHBLL(RecursosHumanosBO rh, AdministradorBO a)
        {
            if (AdministradorBLL.VerificaNivelDeAcessoAdministradorBLL(a))
            {
                if (!VerificaSeExisteRHBLL(rh.IdColaborador)) //se nao existir
                {
                    DadosRecursosHumanos.RegistaRH(rh); //regista
                }
                return true;
            }
            else
            {
                return false;   //problema no acesso
            }
        }

        /// <summary>
        /// dispensar rh
        /// </summary>
        /// <param name="idRH"></param>
        /// <param name="a"></param>
        /// <returns>true -> removido com sucesso
        ///          false-> se admin nao tiver acesso ou o rh nao existir
        /// </returns>
        public static bool DispensaRHBLL(int idRH, AdministradorBO a)
        {
            if (AdministradorBLL.VerificaNivelDeAcessoAdministradorBLL(a)) //se admin tiver acesso...
            {
                if (VerificaSeExisteRHBLL(idRH))    //se exitir RH
                {
                    DadosRecursosHumanos.DispensaRH(idRH);  // remove
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// verifica se um determinado rh existe no sistema
        /// </summary>
        /// <param name="idRH"></param>
        /// <returns>true -> existe
        ///          false-> nao existe
        /// </returns>
        public static bool VerificaSeExisteRHBLL(int idRH)
        {
            return DadosRecursosHumanos.VerificaSeExisteRH(idRH);
        }

        /// <summary>
        /// Gerar um novo id unico
        /// </summary>
        /// <returns>novo id</returns>
        public static int DevolveNovoIdRHBLL()
        {
            return 1 + DadosRecursosHumanos.DevolveIdRH();
        }

        /// <summary>
        /// Listagem dos dados do RH
        /// </summary>
        /// <param name="a"></param>
        /// <returns>retorna true -> se o Administrador estiver no ativo
        ///                       -> se tiver o nivel de acesso autorizado
        /// </returns>false -> nao tiver acesso
        ///                 -> nao esta' no ativo
        public static bool ListagemRHBLL(AdministradorBO a)
        {
            if (AdministradorBLL.VerificaNivelDeAcessoAdministradorBLL(a))
            {
                Console.WriteLine("\n# Listagem Recursos Humanos");
                DadosRecursosHumanos.ListagemRH();
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Metodo que verifica se o rh esta' no ativo e se tem o acesso devido
        /// </summary>
        /// <param name="idRH"></param>
        /// <returns>true -> se estiver no ativo e se tiver acesso
        ///          false-> se estiver no ativo
        ///                  se nao tiver acesso
        /// </returns>
        public static bool VerificaNivelDeAcessoRHBLL(int idRH)
        {
            if (VerificaSeExisteRHBLL(idRH))         //existe?
            {
                if (DadosRecursosHumanos.RHEstaNoAtivo(idRH))   //esta' no ativo?
                {
                    //Verifica os niveis de acesso correspondem
                    return (int)PessoaBO.ENUM_NIVEL_ACESSO.RecursosHumanos == DadosRecursosHumanos.VerificaNivelDeAcesso(idRH);
                }
                else
                {
                    return false;   //nao esta no ativo
                }
            }
            else
            {
                //nao existe
                return false;
            }
        }

        /// <summary>
        /// Metodo que realiza um backup dos dados dos Recursos Humanos
        /// </summary>
        /// <param name="IdGerente"></param>
        /// <returns>string com o caminho de destino
        ///         ou mensagem de erro
        /// </returns>
        public static string FazerBackupRHBLL(int IdGerente)
        {
            if (GerenteOperacionalBLL.VerificaNivelDeAcessoGerenteBLL(IdGerente))
            {
                return DadosRecursosHumanos.FazerBackupRH();
            }
            else
            {
                return "Acesso Negado!";
            }
        }

        /// <summary>
        /// Metodo que restaura um backup dos dados dos recursos humanos
        /// </summary>
        /// <param name="IdGerente"></param>
        /// <returns>string com o caminho
        ///         ou mensagem de erro
        /// </returns>
        public static string RestaurarBackupRHBLL(int IdGerente)
        {
            if (GerenteOperacionalBLL.VerificaNivelDeAcessoGerenteBLL(IdGerente))
            {
                return DadosRecursosHumanos.RestaurarBackupRH();
            }
            else
            {
                return "Acesso Negado!";
            }
        }
    }
}