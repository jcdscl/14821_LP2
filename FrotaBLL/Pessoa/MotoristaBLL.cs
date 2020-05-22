//-------------------------------------------------------------------------------------------
// <copyright file="MotoristaBLL.cs" company="IPCA - Instituto Politecnico do Cavado e do Ave">
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
    public class MotoristaBLL
    {
        /// <summary>
        /// Adicionar novo motorista no sistema
        /// </summary>
        /// <param name="m"></param>
        /// <param name="idRH"></param>
        /// <returns>true -> rh tem acesso mas motorista ja registado
        ///          false-> se admin nao tiver acesso ou o rh já existe
        /// </returns>
        public static bool RegistaMotoristaBLL(MotoristaBO m, int idRH)
        {
            if (RecursosHumanosBLL.VerificaNivelDeAcessoRHBLL(idRH))
            {
                if (!VerificaSeExiste(m.IdColaborador))
                {
                    DadosMotoristas.RegistaMotorista(m);
                }
                return true;
            }
            else
            {
                return false;   //problema no acesso
            }
        }

        /// <summary>
        /// verifica apenas se existe o id no dicionario
        /// </summary>
        /// <param name="id"></param>
        /// <returns>true -> se existir o id
        ///          false-> se nao exitir o id no sistema
        /// </returns>
        public static bool VerificaSeExiste(int id)
        {
            return DadosMotoristas.VerificaSeExisteMotorista(id);
        }

        /// <summary>
        /// Realizar pedido de um carro
        /// </summary>
        /// <param name="idMotorista"></param>
        /// <param name="matricula"></param>
        /// <returns></returns>
        public static bool PedirVeiculoBLL(int idMotorista, string matricula)
        {
            // Motorista tem que existir, estar no ativo e ter nivel de acesso
            //Matricula existir, e veiculo estar disponivel
            if ((MotoristaBLL.VerificaNivelDeAcessoMotoristaBLL(idMotorista) && VeiculoBLL.VerificaSeExisteVeiculoBLL(matricula))
                && (int)VeiculoBLL.DevolveEstadoVeiculo(matricula) == (int)VeiculoBO.ENUM_ESTADO_VEICULO.disponivel)
            {
                DateTime agora = DateTime.Now;

                AtribuicaoVeiculoBO pedido = new AtribuicaoVeiculoBO(DadosVeiculos.DevolveIdAtribuicao(),
                                                                     matricula,
                                                                     idMotorista,
                                                                     AtribuicaoVeiculoBO.ENUM_ESTADO_ATRIBUICAO.faltaRever);

                DadosVeiculos.NovaAtribuicao(agora, pedido);

                return true;        //tudo correu bem
            }
            else
            {
                return false; // !(Motorista tem que existir, estar no ativo e ter nivel de acesso)  ||
                              //  !(Matricula existir, e veiculo estar disponivel)
            }
        }

        /// <summary>
        /// dispensar um motorista
        /// </summary>
        /// <param name="idMotorista"></param>
        /// <param name="idRH"></param>
        /// <returns>true -> Registado com sucesso
        ///          false-> se RH nao tiver acesso ou o motorista nao existir
        /// </returns>
        public static bool DispensaMotoristaBLL(int idMotorista, int idRH)
        {
            if (RecursosHumanosBLL.VerificaNivelDeAcessoRHBLL(idRH)) // rh tem acesso?
            {
                if (VerificaSeExiste(idMotorista))  // motorista existe?
                {
                    DadosMotoristas.DispensaMotorista(idMotorista); //dispensa
                    if (DadosVeiculos.TemVeiculoAtribuido(idMotorista)) //verifica se tem veiculo ou atribuicao pendente
                    {
                        DadosVeiculos.LibertarVeiculoAtribuicoes(idMotorista); //atribuicao fica invalida e veiculo disponivel
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// devolve novo id para o motorista
        /// </summary>
        /// <returns></returns>
        public static int DevolveNovoIdMotorista()
        {
            return 1 + DadosMotoristas.DevolveIdMotorista();
        }

        /// <summary>
        /// Listagem dos dados dos motoristas
        /// </summary>
        /// <param name="idRH"></param>
        /// <returns>retorna true -> se o rh estiver no ativo
        ///                       -> se tiver o nivel de acesso autorizado
        /// </returns>false -> nao tiver acesso
        ///                 -> nao esta' no ativo
        public static bool ListagemMotoristaBLL(int idRH)
        {
            if (RecursosHumanosBLL.VerificaNivelDeAcessoRHBLL(idRH))    // tem acesso?
            {
                DadosMotoristas.ListagemMotoristas();   //lista
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Metodo que verifica se o motorista esta' no ativo e se tem o acesso devido
        /// </summary>
        /// <param name="id"></param>
        /// <returns>true -> se estiver no ativo e se tiver acesso
        ///          false-> se estiver no ativo
        ///                  se nao tiver acesso
        /// </returns>
        public static bool VerificaNivelDeAcessoMotoristaBLL(int id)
        {
            if (VerificaSeExiste(id))         //existe?
            {
                if (DadosMotoristas.MotoristaEstaNoAtivo(id))   //esta' no ativo?
                {
                    //Verifica os niveis de acesso correspondem
                    return (int)PessoaBO.ENUM_NIVEL_ACESSO.Motorista == DadosMotoristas.VerificaNivelDeAcesso(id);
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
        /// Metodo que realiza um backup dos dados dos motoristas
        /// </summary>
        /// <param name="IdGerente"></param>
        /// <returns>string com o caminho de destino
        ///         ou mensagem de erro
        /// </returns>
        public static string FazerBackupMotoristasBLL(int IdGerente)
        {
            if (GerenteOperacionalBLL.VerificaNivelDeAcessoGerenteBLL(IdGerente))
            {
                return DadosMotoristas.FazerBackupMotoristas();
            }
            else
            {
                return "Acesso Negado!";
            }
        }

        /// <summary>
        /// Metodo que restaura um backup dos dados dos motoristas
        /// <returns>string com o caminho
        ///         ou mensagem de erro
        /// </returns>
        public static string RestaurarBackupRHBLL(int IdGerente)
        {
            if (GerenteOperacionalBLL.VerificaNivelDeAcessoGerenteBLL(IdGerente))
            {
                return DadosMotoristas.RestaurarBackupMotoristas();
            }
            else
            {
                return "Acesso Negado!";
            }
        }

        /// <summary>
        /// permite ao motorista consultar o pedido
        /// </summary>
        /// <param name="idMotorista"></param>
        public static void ConsultarMeuPedido(int idMotorista)
        {
            if (VerificaNivelDeAcessoMotoristaBLL(idMotorista))
            {
                DadosVeiculos.ConsultarAtribuicao(idMotorista);
            }
            else
            {
                Console.WriteLine("Acesso Negado!");
            }
        }
    }
}