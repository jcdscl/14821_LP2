//-------------------------------------------------------------------------------------------
// <copyright file="MotoristaBO.cs" company="IPCA - Instituto Politecnico do Cavado e do Ave">
// </copyright>
// <description>Gestao Frota Veiculos</description>
// <date>10/05/2020</date>
// <author>Jose Loureiro</author>
// <email>a14821@alunos.ipca.pt</email>
//-------------------------------------------------------------------------------------------

using System;

namespace FrotaBO
{
    /// <summary>
    /// classe para gerir objetos
    /// </summary>
    [Serializable]
    public class MotoristaBO : ColaboradorBO
    {
        #region ATRIBUTOS

        private DateTime validade;

        #endregion ATRIBUTOS

        #region CONSTRUTORES

        public MotoristaBO(DateTime validade,
                             int idColaborador,
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
            Validade = validade;
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

        public DateTime Validade
        {
            get; set;
        }

        #endregion PORPERTIES
    }
}