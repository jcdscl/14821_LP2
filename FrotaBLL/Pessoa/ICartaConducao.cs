//-------------------------------------------------------------------------------------------
// <copyright file="ICartaConducao.cs" company="IPCA - Instituto Politecnico do Cavado e do Ave">
// </copyright>
// <description>Gestao Frota Veiculos</description>
// <date>11/04/2020</date>
// <author>Jose Loureiro</author>
// <email>a14821@alunos.ipca.pt</email>
//-------------------------------------------------------------------------------------------

namespace FrotaBLL
{
    /// <summary>
    /// Interface carta Conducao para verificar se esta valida
    /// </summary>
    public interface ICartaConducao
    {
        bool VerificaSeValida(int id);
    }
}