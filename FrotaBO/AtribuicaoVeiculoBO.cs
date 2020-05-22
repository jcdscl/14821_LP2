//-------------------------------------------------------------------------------------------
// <copyright file="AtribuicaoVeiculoBO.cs" company="IPCA - Instituto Politecnico do Cavado e do Ave">
// </copyright>
// <description>Gestao Frota Veiculos</description>
// <date>10/05/2020</date>
// <author>Jose Loureiro</author>
// <email>a14821@alunos.ipca.pt</email>
//-------------------------------------------------------------------------------------------
using System;

namespace FrotaBO
{
    /// <summary>
    /// classe gerir objetos
    /// </summary>
    [Serializable]
    public class AtribuicaoVeiculoBO
    {
        #region ATRIBUTOS

        private int idReserva;
        private string matriculaVeiculo;
        private int idColaborador;
        private ENUM_ESTADO_ATRIBUICAO estadoAtribuicao;

        #endregion ATRIBUTOS

        #region CONSTRUTORES

        public AtribuicaoVeiculoBO(int idReserva,
                                   string matriculaVeiculo,
                                   int idColaborador,
                                   ENUM_ESTADO_ATRIBUICAO estadoAtribuicao)
        {
            IdReserva = idReserva;
            MatriculaVeiculo = matriculaVeiculo;
            IdColaborador = idColaborador;
            EstadoAtribuicao = estadoAtribuicao;
        }

        #endregion CONSTRUTORES

        #region PORPERTIES

        /// <summary>
        /// Handle the atribute "idReserva" (auto generated id)
        /// </summary>
        public int IdReserva { get; private set; }

        /// <summary>
        /// Handle the atribute "idColaborador"
        /// </summary>
        public int IdColaborador { get => idColaborador; set => idColaborador = value; }

        /// <summary>
        /// Handle the atribute "matricula"
        /// </summary>
        public string MatriculaVeiculo { get => matriculaVeiculo; set => matriculaVeiculo = value; }

        public ENUM_ESTADO_ATRIBUICAO EstadoAtribuicao { get => estadoAtribuicao; set => estadoAtribuicao = value; }

        #endregion PORPERTIES

        #region ENUM

        public enum ENUM_ESTADO_ATRIBUICAO
        {
            revistoAprovada,
            faltaRever,
            revistoReprovada,
            invalida,
        };

        #endregion ENUM
    }
}