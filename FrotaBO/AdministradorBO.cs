//-------------------------------------------------------------------------------------------
// <copyright file="AdministradorBO.cs" company="IPCA - Instituto Politecnico do Cavado e do Ave">
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
    /// Classe gerir objetos
    /// </summary>
    [Serializable]
    public class AdministradorBO : PessoaBO
    {
        #region ATRIBUTOS

        private int idAdministrador;

        #endregion ATRIBUTOS

        #region CONSTRUCTORS

        public AdministradorBO(int idAdministrador,
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
            IdAdministrador = idAdministrador;
            NomeCompleto = nomeCompleto;
            NIF1 = NIF;
            DataNasciemnto = dataNasciemnto;
            NumeroTelemovel = numeroTelemovel;
            Email = email;
            NivelAcesso = nivelAcesso;
            EmAtividade = emAtividade;
        }

        #endregion CONSTRUCTORS

        #region PROPERTIES

        /// <summary>
        /// Handle the atribute "idAdministrador" (auto generated)
        /// </summary>
        public int IdAdministrador { get; private set; } //usar private no set identificador global unico

        #endregion PROPERTIES
    }
}