//-------------------------------------------------------------------------------------------
// <copyright file="GerenteBO.cs" company="IPCA - Instituto Politecnico do Cavado e do Ave">
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
    public class GerenteBO : PessoaBO
    {
        #region ATRIBUTOS

        private int idGerente;

        #endregion ATRIBUTOS

        #region CONSTRUTORES

        public GerenteBO(int idGerente,
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
            IdGerente = idGerente;
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

        public int IdGerente { get; private set; }

        #endregion PORPERTIES
    }
}