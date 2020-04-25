//-------------------------------------------------------------------------------------------
// <copyright file="ColaboradorBLL.cs" company="IPCA - Instituto Politecnico do Cavado e do Ave">
// </copyright>
// <description>Gestao Frota Veiculos</description>
// <date>11/04/2020</date>
// <time>12:05</time>
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
    class ColaboradorBLL : PessoaBLL
    {
        #region ATTRIBUTES
        private Guid idColaborador;
        #endregion

        #region CONSTRUCTORS
        //fase 2
        #endregion

        #region PROPERTIES
        /// <summary>
        /// Handle the atribute "idColaborador" (auto generated id)
        /// </summary>
        public Guid IdColaborador { get; private set ; } //definir private
        #endregion

        #region ENUM
        #endregion
    }
}
