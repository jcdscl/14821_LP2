//-------------------------------------------------------------------------------------------
// <copyright file="ColaboradorBO.cs" company="IPCA - Instituto Politecnico do Cavado e do Ave">
// </copyright>
// <description>Gestao Frota Veiculos</description>
// <date>11/05/2020</date>
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
    public class ColaboradorBO : PessoaBO
    {
        #region ATRIBUTOS

        private int idColaborador;

        #endregion ATRIBUTOS

        #region CONSTRUTORES

        public ColaboradorBO(int idColaborador,
                             string nomeCompleto,
                             string NIF,
                             DateTime dataNasciemnto,
                             string numeroTelemovel,
                             string email,
                             ENUM_NIVEL_ACESSO nivelAcesso,
                             bool emAtividade)
                       : base(nomeCompleto,
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

        #region PORPERTIES

        public int IdColaborador { get; set; }

        #endregion PORPERTIES
    }
}