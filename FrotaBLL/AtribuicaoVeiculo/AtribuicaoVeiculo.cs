//-------------------------------------------------------------------------------------------
// <copyright file="AtribuicaoVeiculo.cs" company="IPCA - Instituto Politecnico do Cavado e do Ave">
// </copyright>
// <description>Gestao Frota Veiculos</description>
// <date>11/04/2020</date>
// <time>12:06</time>
// <author>Jose Loureiro</author>
// <email>a14821@alunos.ipca.pt</email>
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrotaBLL.AtribuicaoVeiculo
{
    class AtribuicaoVeiculo
    {

        #region ATTRIBUTES
        private Guid idReserva;
        private int idVeiculo;
        private int idColaborador;
        private bool aprovado;

        #endregion

        #region CONSTRUCTORS
        //fase 
        #endregion


        #region PORPERTIES
        /// <summary>
        /// Handle the atribute "idReserva" (auto generated id)
        /// </summary>
        public Guid IdReserva { get; private set; }

        /// <summary>
        /// Handle the atribute "aprovado"
        /// </summary>
        public bool Aprovado { get => aprovado; set => aprovado = value; }

        /// <summary>
        /// Handle the atribute "idColaborador"
        /// </summary>
        public int IdColaborador { get => idColaborador; set => idColaborador = value; }

        /// <summary>
        /// Handle the atribute "idVeiculo"
        /// </summary>
        public int IdVeiculo { get => idVeiculo; set => idVeiculo = value; }
        #endregion


        #region METHODS
        //fase 2
        #endregion

        #region ENUM
        #endregion

    }
}
