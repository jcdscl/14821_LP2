//-------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="IPCA - Instituto Politecnico do Cavado e do Ave">
// </copyright>
// <description>Gestao Frota Veiculos</description>
// <date>11/04/2020</date>
// <author>Jose Loureiro</author>
// <email>a14821@alunos.ipca.pt</email>
//-------------------------------------------------------------------------------------------

using System;
using FrotaBLL;
using FrotaBO;
using static FrotaBO.PessoaBO;

namespace FrotaUI
{
    public class Program
    {
        private static void Main(string[] args)
        {
            //#region REGISTO_LISTAGEM

            //#region ADMINISTRADOR

            AdministradorBO a1 = new AdministradorBO(AdministradorBLL.NovoIdAdministradorBLL(),
                                               "José Loureiro",
                                               "219182191",
                                                new DateTime(1999, 1, 26),
                                               "964309966",
                                               "jcdscl99@gmail.com",
                                               ENUM_NIVEL_ACESSO.Administrador,
                                               true);
            AdministradorBLL.RegistarAdmistradorBLL(a1);

            //AdministradorBO a2 = new AdministradorBO(AdministradorBLL.NovoIdAdministradorBLL(),
            //                                    "Carlos Loureiro",
            //                                    "119482191",
            //                                   new DateTime(1912, 11, 6),
            //                                    "964303826",
            //                                    "cl99mail.com",
            //                                    ENUM_NIVEL_ACESSO.Administrador,
            //                                    true);

            //AdministradorBLL.RegistarAdmistradorBLL(a2);

            //AdministradorBO a3 = new AdministradorBO(AdministradorBLL.NovoIdAdministradorBLL(),
            //                                    "Luis Loureiro",
            //                                    "219182191",
            //                                    new DateTime(1999, 1, 26),
            //                                    "964309966",
            //                                    "jcdscl99@gmail.com",
            //                                    ENUM_NIVEL_ACESSO.Administrador,
            //                                    true);

            //AdministradorBLL.RegistarAdmistradorBLL(a3);

            //AdministradorBLL.ListagemAdministradoresBLL(a1);

            //#endregion ADMINISTRADOR

            //#region GERENTE

            GerenteBO g1 = new GerenteBO(GerenteOperacionalBLL.DevolveNovoIdGerenteBLL(),
                                         "Luis Silva",
                                         "219182191",
                                         new DateTime(1942, 5, 15),
                                         "914312966",
                                         "jcds@gmail.com",
                                         ENUM_NIVEL_ACESSO.GerenteOperacional,
                                         true);

            GerenteOperacionalBLL.RegistaGerenteBLL(g1, a1);
            GerenteOperacionalBLL.ListagemGerentesBLL(a1);

            //#endregion GERENTE

            //#region VEICULO

            //VeiculoBO carro = new VeiculoBO("12-12-BN", "bmw", "preto", VeiculoBO.ENUM_ESTADO_VEICULO.disponivel);
            //VeiculoBO carro2 = new VeiculoBO("02-27-99", "opel", "azul", VeiculoBO.ENUM_ESTADO_VEICULO.disponivel);
            //VeiculoBO carro3 = new VeiculoBO("AA-16-dh", "ferrari", "preto", VeiculoBO.ENUM_ESTADO_VEICULO.disponivel);

            //FrotaBLL.VeiculoBLL.RegistaVeiculoBLL(carro,1);
            //FrotaBLL.VeiculoBLL.RegistaVeiculoBLL(carro2, 1);
            //FrotaBLL.VeiculoBLL.RegistaVeiculoBLL(carro3, 1);

            VeiculoBLL.ListarFrotaVeiculosBLL(1);

            //#endregion VEICULO

            //#region RH

            //RecursosHumanosBO rh1 = new RecursosHumanosBO(RecursosHumanosBLL.DevolveNovoIdRHBLL(),
            //                                               "Maria Silva",
            //                                               "112212112",
            //                                              new DateTime(1928, 4, 8),
            //                                              "13212121",
            //                                              "mail@mail.com",
            //                                              ENUM_NIVEL_ACESSO.RecursosHumanos,
            //                                              true);
            //RecursosHumanosBLL.RegistaRHBLL(rh1, a1);
            //RecursosHumanosBLL.ListagemRHBLL(a1);

            //#endregion

            //#region MOTORISTA

            //MotoristaBO m1 = new MotoristaBO(new DateTime(2021, 12, 2),
            //                                MotoristaBLL.DevolveNovoIdMotorista(),
            //                                "Ambrosio Pereira",
            //                                "178356172",
            //                                new DateTime(1981, 8, 17),
            //                                "911727112",
            //                                "ambro@mail.co",
            //                                ENUM_NIVEL_ACESSO.Motorista,
            //                                true);
            //MotoristaBLL.RegistaMotoristaBLL(m1, 1);
            MotoristaBLL.ListagemMotoristaBLL(1);
            //#endregion

            //#endregion

            //#region ATRIBUICAO

            //MotoristaBLL.PedirVeiculoBLL(1, "12-12-BN");
            //MotoristaBLL.ConsultarMeuPedido(1);

            //#endregion

            //GerenteOperacionalBLL.ReverAtribuicaoBLL(1, 1);

            //MotoristaBLL.ConsultarMeuPedido(1);

            #region BACKUPS

            GerenteOperacionalBLL.RestaurarBackupGeral(1);

            #endregion BACKUPS

            VeiculoBLL.ListarFrotaVeiculosBLL(1);

            Console.WriteLine("FIIMMMM");
            Console.ReadKey();
        }
    }
}