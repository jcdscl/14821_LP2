//-------------------------------------------------------------------------------------------
// <copyright file="MotoristaBLL.cs" company="IPCA - Instituto Politecnico do Cavado e do Ave">
// </copyright>
// <description>Gestao Frota Veiculos</description>
// <date>11/04/2020</date>
// <time>12:02</time>
// <author>Jose Loureiro</author>
// <email>a14821@alunos.ipca.pt</email>
//-------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrotaBLL
{
    class MotoristaBLL : ColaboradorBLL, ICartaConducao
    {
        #region ATTRIBUTES
        private bool cartaConducaoValida;
        #endregion

        #region CONSTRUCTORS
        //fase 2
        #endregion

        #region PROPERTIES
        /// <summary>
        /// Handle the atribute "cartaConducaoValida"
        /// </summary>
        public bool CartaConducaoValida { get => cartaConducaoValida; set => cartaConducaoValida = value; }
        #endregion

        #region METHODS
        /// <summary>
        /// Metodo que verifica se a carta de conducao esta valida
        /// </summary>
        /// <param name="valida"></param>
        /// <returns></returns>
        public bool VerificaSeValida(bool valida)
        {
            if (CartaConducaoValida) { return true; }
            else { return false; };
        }
        #endregion
    }
}
