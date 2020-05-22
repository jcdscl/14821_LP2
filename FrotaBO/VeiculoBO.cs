//-------------------------------------------------------------------------------------------
// <copyright file="VeiculoBO.cs" company="IPCA - Instituto Politecnico do Cavado e do Ave">
// </copyright>
// <description>Gestao Frota Veiculos</description>
// <date>11/04/2020</date>
// <author>Jose Loureiro</author>
// <email>a14821@alunos.ipca.pt</email>
//-------------------------------------------------------------------------------------------
using System;

namespace FrotaBO
{
    /// <summary>
    /// gerir objeto
    /// </summary>
    [Serializable]
    public class VeiculoBO
    {
        #region ATRIBUTOS

        private string matricula;
        private string fabricante;
        private string cor;
        private ENUM_ESTADO_VEICULO estadoVeiculo;

        #endregion ATRIBUTOS

        #region CONSTRUTORES

        public VeiculoBO(string matricula,
                       string fabricante,
                       string cor,
                       ENUM_ESTADO_VEICULO estadoVeiculo)
        {
            Matricula = matricula;
            Fabricante = fabricante;
            Cor = cor;
            EstadoVeiculo = estadoVeiculo;
        }

        #endregion CONSTRUTORES

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
        public ENUM_ESTADO_VEICULO EstadoVeiculo { get => estadoVeiculo; set => estadoVeiculo = value; }

        #endregion PROPERTIES

        #region ENUM

        public enum ENUM_ESTADO_VEICULO
        {
            indisponivel, // ex: manutencao, vendido ...
            disponivel,   // pronto para ser atribuido
            atribuido,    // se ja' tiver motorista
        };

        #endregion ENUM
    }
}