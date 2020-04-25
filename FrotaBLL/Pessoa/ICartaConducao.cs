//-------------------------------------------------------------------------------------------
// <copyright file="ICartaConducao.cs" company="IPCA - Instituto Politecnico do Cavado e do Ave">
// </copyright>
// <description>Gestao Frota Veiculos</description>
// <date>11/04/2020</date>
// <time>12:04</time>
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
    /// <summary>
    /// Interface carta Conducao para verificar se esta valida
    /// </summary>
    interface ICartaConducao
    {
        bool VerificaSeValida(bool valida);
    }
}
