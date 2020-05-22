//-------------------------------------------------------------------------------------------
// <copyright file="GerenteOperacionalBLL.cs" company="IPCA - Instituto Politecnico do Cavado e do Ave">
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
    /// Classe responsavel por ditar a logica e regras
    /// </summary>
    public class GerenteOperacionalBLL : ICartaConducao
    {
        public static GerenteOperacionalBLL gBLL = new GerenteOperacionalBLL();

        /// <summary>
        /// Metodo que verifica se a carta de conducao esta valida
        /// </summary>
        /// <param name="id"></param>
        /// <returns>true -> esta' valida
        ///          false-> nao esta' valida (expira hoje ou já expirou)
        /// </returns>
        public bool VerificaSeValida(int id)
        {
            int diferenca = DateTime.Compare(DadosMotoristas.DevolveValidade(id), DateTime.Now);//compara com a data de hoje

            if (diferenca <= 0)    //Ja' expirou ou expira hoje
            {
                return false;
            }
            else
            {
                return true;        //Esta' valida
            }
        }

        /// <summary>
        /// Adicionar novo gerente no sistema
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns>true -> Registado com sucesso
        ///          false-> se admin nao tiver acesso ou o gerente já existe
        /// </returns>
        public static bool RegistaGerenteBLL(GerenteBO g, AdministradorBO a)
        {
            if (AdministradorBLL.VerificaNivelDeAcessoAdministradorBLL(a))  //tem acesso?
            {
                if (!VerificaSeExisteGerenteBLL(g.IdGerente))        //ja' existe?
                {
                    DadosGerentes.RegistaGerente(g);    //regista
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// dispensar gerente
        /// </summary>
        /// <param name="idGerente"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool DispensaGerenteBLL(int idGerente, AdministradorBO a)
        {
            if (AdministradorBLL.VerificaNivelDeAcessoAdministradorBLL(a))
            {
                if (VerificaSeExisteGerenteBLL(idGerente))
                {
                    DadosGerentes.DispensaGerente(idGerente);
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// verifica se um determinado gerente existe no sistema
        /// </summary>
        /// <param name="idGerente"></param>
        /// <returns>true -> se existir o id
        ///          false-> se nao exitir o id no sistema
        /// </returns>
        public static bool VerificaSeExisteGerenteBLL(int idGerente)
        {
            return DadosGerentes.VerificaSeExisteGerente(idGerente);
        }

        /// <summary>
        /// Listagem dos dados dos gerentes
        /// </summary>
        /// <param name="a"></param>
        /// <returns>retorna true -> se o Administrador estiver no ativo
        ///                       -> se tiver o nivel de acesso auto
        /// </returns>false -> nao tiver acesso
        ///                 -> nao esta' no ativo
        public static bool ListagemGerentesBLL(AdministradorBO a)
        {
            if (AdministradorBLL.VerificaNivelDeAcessoAdministradorBLL(a))
            {
                Console.WriteLine("\n# Listagem Gerentes:");
                DadosGerentes.ListagemGerentes();
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Metodo que verifica se o gerente esta' no ativo e se tem o acesso devido
        /// </summary>
        /// <param name="id"></param>
        /// <returns>true -> (se estiver no ativo) se tiver acesso
        ///          false-> se estiver no ativo
        ///                  se nao tiver acesso
        ///                  se nao existir
        /// </returns>
        public static bool VerificaNivelDeAcessoGerenteBLL(int id)
        {
            if (VerificaSeExisteGerenteBLL(id))
            {
                if (DadosGerentes.GerenteEstaNoAtivo(id))
                {
                    //Verifica os niveis de acesso correspondem
                    return (int)PessoaBO.ENUM_NIVEL_ACESSO.GerenteOperacional == DadosGerentes.VerificaNivelDeAcesso(id);
                }
                else
                {
                    // nao esta' no ativo ou nao existe
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// metodo que gera um novo ID
        /// </summary>
        /// <returns>int -> novo ID</returns>
        public static int DevolveNovoIdGerenteBLL()
        {
            return 1 + DadosGerentes.DevolveIdGerente();
        }

        /// <summary>
        /// Metodo em que o gerente reve as atribuicoes da frota
        /// </summary>
        /// <param name="idGerente"></param>
        /// <param name="idMotorista"></param>
        /// <returns></returns>
        public static bool ReverAtribuicaoBLL(int idGerente, int idMotorista)
        {
            if (VerificaNivelDeAcessoGerenteBLL(idGerente))  //gerente tem acesso/existe/ativo
            {
                DadosVeiculos.ListarAtribuicoes();  //visao geral das atribuicoes
                Console.WriteLine("");

                //verifica se a carta esta' em dia e se motorista existe, esta' no ativo
                if (MotoristaBLL.VerificaNivelDeAcessoMotoristaBLL(idMotorista))
                {
                    if (gBLL.VerificaSeValida(idMotorista)) //verifica se esta' valida
                    {
                        DadosVeiculos.ReverAtribuicao(idMotorista, 1); //valido
                    }
                    else
                    {
                        DadosVeiculos.ReverAtribuicao(idMotorista, 0); //invalido
                    }
                    return true;   //operacao realizada corretamente
                }
                else
                {
                    return false; // problemas no acesso do motorista
                }
            }
            else
            {
                return false;   //problemas na autenticacao do gerente
            }
        }

        /// <summary>
        /// consultar uma atribuicao
        /// </summary>
        /// <param name="idMotorista"></param>
        /// <param name="idGerente"></param>
        public static void ConsultarAtribuicaoBLL(int idMotorista, int idGerente)
        {
            if (VerificaNivelDeAcessoGerenteBLL(idGerente))
            {
                DadosVeiculos.ConsultarAtribuicao(idMotorista);
            }
        }

        /// <summary>
        /// Metodo que realiza um backup dos dados dos gerentes
        /// </summary>
        /// <param name="idGerente"></param>
        /// <returns>string com o caminho de destino
        ///         ou mensagem de erro
        /// </returns>
        public static string FazerBackupGerenteBLL(int idGerente)
        {
            if (VerificaNivelDeAcessoGerenteBLL(idGerente))
            {
                return DadosGerentes.FazerBackupFrota();
            }
            else
            {
                return "Acesso Negado!";
            }
        }

        /// <summary>
        /// Metodo que restaura um backup dos dados dos gerentes
        /// </summary>
        /// <param name="idGerente"></param>
        /// <returns>string com o caminho
        ///         ou mensagem de erro
        /// </returns>
        public static string RestaurarBackupGerenteBLL(int idGerente)
        {
            if (VerificaNivelDeAcessoGerenteBLL(idGerente))
            {
                return DadosGerentes.RestaurarBackupFrota();
            }
            else
            {
                return "Acesso Negado!";
            }
        }

        /// <summary>
        /// metodo permite fazer Backup Geral na aplicacao
        /// </summary>
        /// <param name="idGerente"></param>
        public static void FazerBackupGeral(int idGerente)
        {
            if (VerificaNivelDeAcessoGerenteBLL(idGerente))
            {
                AdministradorBLL.FazerBackupAdministradorBLL();
                GerenteOperacionalBLL.FazerBackupGerenteBLL(idGerente);
                RecursosHumanosBLL.FazerBackupRHBLL(idGerente);
                MotoristaBLL.FazerBackupMotoristasBLL(idGerente);
                VeiculoBLL.FazerBackupFrotaBLL(idGerente);
                VeiculoBLL.FazerBackupAtribuicoes(idGerente);
            }
            else
            {
                Console.WriteLine("Acesso negado!");
            }
        }

        /// <summary>
        /// Realizar restauro geral dos backups
        /// </summary>
        /// <param name="idGerente"></param>
        public static void RestaurarBackupGeral(int idGerente)
        {
            if (GerenteOperacionalBLL.VerificaNivelDeAcessoGerenteBLL(idGerente))
            {
                AdministradorBLL.RestaurarBackupAdministradorBLL();
                GerenteOperacionalBLL.RestaurarBackupGerenteBLL(idGerente);
                RecursosHumanosBLL.RestaurarBackupRHBLL(idGerente);
                MotoristaBLL.RestaurarBackupRHBLL(idGerente);
                VeiculoBLL.RestaurarBackupFrotaBLL(idGerente);
                VeiculoBLL.RestaurarBackupAtribuicoes(idGerente);
            }
            else
            {
                Console.WriteLine("Acesso Negado!");
            }
        }
    }
}