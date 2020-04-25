//-------------------------------------------------------------------------------------------
// <copyright file="AdministradorBLL.cs" company="IPCA - Instituto Politecnico do Cavado e do Ave">
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
    class AdministradorBLL : PessoaBLL
    {
        #region ATRIBUTOS
        private Guid idAdministrador;
        #endregion

        #region CONSTRUCTORS
        //fase 2
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Handle the atribute "idAdministrador" (auto generated)
        /// </summary>
        public Guid IdAdministrador { get ; private set; } //usar private no set identificador global unico 
        #endregion

        #region METHODS
        //fase 2
        #endregion

        #region ENUM
        #endregion
    }
}
