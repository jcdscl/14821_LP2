//-------------------------------------------------------------------------------------------
// <copyright file="RecursosHumanosBO.cs" company="IPCA - Instituto Politecnico do Cavado e do Ave">
// </copyright>
// <description>Gestao Frota Veiculos</description>
// <date>10/05/2020</date>
// <author>Jose Loureiro</author>
// <email>a14821@alunos.ipca.pt</email>
//-------------------------------------------------------------------------------------------

using System;

/// <summary>
/// gestao dos objetos
/// </summary>
namespace FrotaBO
{
    [Serializable]
    public class RecursosHumanosBO : ColaboradorBO
    {
        #region CONSTRUTORES

        public RecursosHumanosBO(int idColaborador,
                             string nomeCompleto,
                             string NIF,
                             DateTime dataNasciemnto,
                             string numeroTelemovel,
                             string email,
                             ENUM_NIVEL_ACESSO nivelAcesso,
                             bool emAtividade)
                       : base(idColaborador,
                             nomeCompleto,
                             NIF,
                             dataNasciemnto,
                             numeroTelemovel,
                             email,
                             nivelAcesso,
                             emAtividade)

        {
            IdColaborador = idColaborador;
            NomeCompleto = nomeCompleto;
            NIF1 = NIF;
            DataNasciemnto = dataNasciemnto;
            NumeroTelemovel = numeroTelemovel;
            Email = email;
            NivelAcesso = nivelAcesso;
            EmAtividade = emAtividade;
        }

        #endregion CONSTRUTORES
    }
}