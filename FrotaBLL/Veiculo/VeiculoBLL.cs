//-------------------------------------------------------------------------------------------
// <copyright file="VeiculoBLL.cs" company="IPCA - Instituto Politecnico do Cavado e do Ave">
// </copyright>
// <description>Gestao Frota Veiculos</description>
// <date>12/04/2020</date>
// <author>Jose Loureiro</author>
// <email>a14821@alunos.ipca.pt</email>
//-------------------------------------------------------------------------------------------
using System;
using FrotaBO;
using FrotaDAL;

namespace FrotaBLL
{
    /// <summary>
    /// Classe definimos regras de negocio para os Veiculos
    /// </summary>
    public class VeiculoBLL
    {
        /// <summary>
        /// Metodo que verifica se e' possivel inserir um veiculo
        /// </summary>
        /// <param name="v"></param>
        /// <param name="idGerente"></param>
        /// <returns>true -> registado com sucesso
        ///          false-> gerente nao tem acesso ou carro ja' registado
        /// </returns>
        public static bool RegistaVeiculoBLL(VeiculoBO v, int idGerente)
        {
            if (GerenteOperacionalBLL.VerificaNivelDeAcessoGerenteBLL(idGerente)) // tem acesso?
            {
                if (!DadosVeiculos.VerificaSeExiste(v.Matricula))   //se nao existir
                {
                    DadosVeiculos.RegistaVeiculo(v);    //regista
                    return true;
                }
                else
                {
                    return false; // ja' existe
                }
            }
            else
            {
                return false; //problemas na autenticacao
            }
        }

        /// <summary>
        /// metodo para listar
        /// </summary>
        /// <param name="idGerente"></param>
        /// <returns>true-> listou
        ///          false-> problema no acesso
        /// </returns>
        public static bool ListarFrotaVeiculosBLL(int idGerente)
        {
            if (GerenteOperacionalBLL.VerificaNivelDeAcessoGerenteBLL(idGerente))   // autorizado?
            {
                Console.WriteLine("\n# Listagem Frota");
                DadosVeiculos.ListarFrotaVeiculos();    //lista
                return true;
            }
            else
            {
                return false;   //sem acesso
            }
        }

        /// <summary>
        /// metodo auxiliar que verifica a existencia de uma matricula
        /// </summary>
        /// <param name="matricula"></param>
        /// <returns>true -> existe
        ///          false-> nao existe
        /// </returns>
        public static bool VerificaSeExisteVeiculoBLL(string matricula)
        {
            return DadosVeiculos.VerificaSeExiste(matricula);
        }

        /// <summary>
        /// Dispensar veiculo
        /// </summary>
        /// <param name="matricula"></param>
        /// <param name="idGerente"></param>
        /// <returns>true-> removeu
        ///          false-> problema no acesso ou ja' existe
        /// </returns>
        public static bool RemoverVeiculoBLL(string matricula, int idGerente)
        {
            if (GerenteOperacionalBLL.VerificaNivelDeAcessoGerenteBLL(idGerente)) //autorizado?
            {
                if (VerificaSeExisteVeiculoBLL(matricula))       //existe veiculo?
                {
                    DadosVeiculos.RemoverVeiculo(matricula);    //"remover" veiculo
                    if (DadosVeiculos.TemMotoristaAtribuido(matricula)) //remover dependencias
                    {
                        DadosVeiculos.LibertarVeiculoAtribuicoesII(matricula); //atribuicao fica invalida e veiculo disponivel
                    }
                }
                return true;
            }
            else
            {
                return false;   //falha na autenticacao
            }
        }

        /// <summary>
        /// Guarda dados para um ficheiro binario
        /// </summary>
        /// <returns></returns>
        public static string FazerBackupFrotaBLL(int idGerente)
        {
            if (GerenteOperacionalBLL.VerificaNivelDeAcessoGerenteBLL(idGerente))
            {
                return DadosVeiculos.FazerBackupFrota();
            }
            else
            {
                return "Acesso Negado!";
            }
        }

        /// <summary>
        /// Guardar num ficheiro XML os dados das atribuicoes
        /// </summary>
        /// <param name="idGerente"></param>
        /// <returns>caminho do ficheiro ou erro</returns>
        public static string FazerBackupAtribuicoes(int idGerente)
        {
            if (GerenteOperacionalBLL.VerificaNivelDeAcessoGerenteBLL(idGerente))  //acesso?
            {
                return DadosVeiculos.FazerBackupAtribuicoes();  //faz backup
            }
            else
            {
                return "Erro no Acesso!";   //erro no acesso
            }
        }

        /// <summary>
        /// Metodo que devolve em inteiro, o estado do veiculo ((in)disponivel, atribuido)
        /// </summary>
        /// <param name="matricula"></param>
        /// <returns></returns>
        public static int DevolveEstadoVeiculo(string matricula)
        {
            return (int)DadosVeiculos.DevolveEstadoVeiculo(matricula);
        }

        /// <summary>
        /// Carregar os dados para memoria
        /// </summary>
        /// <returns></returns>
        public static string RestaurarBackupFrotaBLL(int idGerente)
        {
            if (GerenteOperacionalBLL.VerificaNivelDeAcessoGerenteBLL(idGerente))
            {
                return DadosVeiculos.RestaurarBackupFrota();
            }
            else
            {
                return "Acesso Negado!";
            }
        }

        /// <summary>
        /// Devolve novo id atribuicao
        /// </summary>
        /// <returns>int (novo id reserva)</returns>
        public static int DevolveNovoIdAtribuicao()
        {
            return 1 + DadosVeiculos.DelvolveIdReserva();
        }

        /// <summary>
        /// Este metodo permite ao gerente restaurar os dados das atribuicoes
        /// </summary>
        /// <param name="idGerente"></param>
        /// <returns>caminho do ficheiro ou erro</returns>
        public static string RestaurarBackupAtribuicoes(int idGerente)
        {
            if (GerenteOperacionalBLL.VerificaNivelDeAcessoGerenteBLL(idGerente))
            {
                return DadosVeiculos.RestaurarBackupAtribuicoes();
            }
            else
            {
                return "Erro no Acesso!";
            }
        }
    }
}