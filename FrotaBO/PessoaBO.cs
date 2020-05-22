//-------------------------------------------------------------------------------------------
// <copyright file="PessoaBO.cs" company="IPCA - Instituto Politecnico do Cavado e do Ave">
// </copyright>
// <description>Gestao Frota Veiculos</description>
// <date>11/04/2020</date>
// <author>Jose Loureiro</author>
// <email>a14821@alunos.ipca.pt</email>
//-------------------------------------------------------------------------------------------

using System;

namespace FrotaBO
{
    [Serializable]
    public abstract class PessoaBO
    {
        #region ATRIBUTOS

        private string nomeCompleto;
        private string NIF;
        private DateTime dataNasciemnto;
        private string numeroTelemovel;
        private string email;
        private ENUM_NIVEL_ACESSO nivelAcesso;
        private bool emAtividade;

        public PessoaBO()
        {
        }

        public PessoaBO(string nomeCompleto,
                      string NIF,
                      DateTime dataNasciemnto,
                      string numeroTelemovel,
                      string email,
                      ENUM_NIVEL_ACESSO nivelAcesso,
                      bool emAtividade)
        {
            NomeCompleto = nomeCompleto;
            NIF1 = NIF;
            DataNasciemnto = dataNasciemnto;
            NumeroTelemovel = numeroTelemovel;
            Email = email;
            NivelAcesso = nivelAcesso;
            EmAtividade = emAtividade;
        }

        #endregion ATRIBUTOS

        #region PROPERTIES

        /// <summary>
        /// Handle the atribute "dataNascimento",
        /// </summary>
        public DateTime DataNasciemnto
        {
            get => dataNasciemnto;
            set
            {
                DateTime tempDataNascimento;
                // Try parse the received value
                if (DateTime.TryParse(value.ToString(), out tempDataNascimento) == true)
                    dataNasciemnto = tempDataNascimento;
            }
        }

        /// <summary>
        /// Handle the atribute "nomeCompleto"
        /// </summary>
        public string NomeCompleto { get => nomeCompleto; set => nomeCompleto = value; }

        /// <summary>
        /// Handle the atribute "numeroTelemovel"
        /// </summary>
        public string NumeroTelemovel { get => numeroTelemovel; set => numeroTelemovel = value; }

        /// <summary>
        /// Handle the atribute "email"
        /// </summary>
        public string Email { get => email; set => email = value; }

        /// <summary>
        /// Handle the atribute "NIF"
        /// </summary>
        public string NIF1 { get => NIF; set => NIF = value; }

        /// <summary>
        /// Handle de atribute "emAtividade"
        /// </summary>
        public bool EmAtividade { get => emAtividade; set => emAtividade = value; }

        /// <summary>
        /// Handle the atribute "nivelAcesso"
        /// </summary>
        public ENUM_NIVEL_ACESSO NivelAcesso { get => nivelAcesso; set => nivelAcesso = value; }

        #endregion PROPERTIES

        #region ENUM

        /// <summary>
        /// Enum "EnumNivelAcesso" to users
        /// </summary>
        public enum ENUM_NIVEL_ACESSO
        {
            Administrador,
            GerenteOperacional,
            RecursosHumanos,
            Motorista,
            NenhumAcesso,
        };

        #endregion ENUM
    }
}