//-------------------------------------------------------------------------------------------
// <copyright file="PessoaBLL.cs" company="IPCA - Instituto Politecnico do Cavado e do Ave">
// </copyright>
// <description>Gestao Frota Veiculos</description>
// <date>11/04/2020</date>
// <time>12:02</time>
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
    class PessoaBLL
    {
     
        #region ATRIBUTOS
        private string nomeCompleto;
        private string NIF;
        private DateTime dataNasciemnto;
        private string numeroTelemovel;
        private string email;
        private EnumNivelAcesso nivelAcesso;

        #endregion
        
        #region CONSTRUCTORS
        //fase 2
        #endregion

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
        /// Handle the atribute "nivelAcesso"
        /// </summary>
        private EnumNivelAcesso NivelAcesso { get => nivelAcesso; set => nivelAcesso = value; }
        #endregion

        #region ENUM
        /// <summary>
        /// Enum "EnumNivelAcesso" to users
        /// </summary>
        enum EnumNivelAcesso
        {
            Administrador,
            GerenteOperacional,
            RecursosHumanos,
            Motorista,
        
        };
        #endregion
    }

    
}
