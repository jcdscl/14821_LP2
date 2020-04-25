//-------------------------------------------------------------------------------------------
// <copyright file="Veiculo.cs" company="IPCA - Instituto Politecnico do Cavado e do Ave">
// </copyright>
// <description>Gestao Frota Veiculos</description>
// <date>11/04/2020</date>
// <time>11:53</time>
// <author>Jose Loureiro</author>
// <email>a14821@alunos.ipca.pt</email>
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrotaBLL.Veiculo
{
    class Veiculo
    {
        #region ATRIBUTOS
        private string matricula;
        private string fabricante;
        private string cor;
        private EnumEstadoVeiculo estadoVeiculo;


        #endregion

        #region PROPERTIES
        /// <summary>
        /// Handle the atribute "matricula"
        /// </summary>
        public string Matricula { get => matricula; set => matricula = value; }

        /// <summary>
        /// Handle the atribute "fabricante" 
        /// </summary>
        public string Fabricante { get => fabricante; set => fabricante = value; }

        /// <summary>
        /// Handle the "atribute "cor"
        /// </summary>
        public string Cor { get => cor; set => cor = value; }

        /// <summary>
        /// Handle the atribute "EnumEstadoVeiculo"
        /// </summary>
        private EnumEstadoVeiculo EstadoVeiculo { get => estadoVeiculo; set => estadoVeiculo = value; }
        #endregion

        #region ENUM
        enum EnumEstadoVeiculo
        {
            indisponivel,
            disponivel,
        };
        #endregion


    }

}
