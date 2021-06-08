using System;
using System.Collections.Generic;

namespace FitnessStore.API.Models.DTO
{
    /// <summary>
    /// DTO dos usuários do sistema.
    /// </summary>
    public class DTODeUsuario
    {
        /// <summary>
        /// Construtor da classe.
        /// </summary>
        public DTODeUsuario()
        {
            Refeicoes = new List<DTODeRefeicao>();
        }

        /// <summary>
        /// Identificador do usuário.
        /// </summary>
        public int CodigoUsuario { get; set; }

        /// <summary>
        /// Nome completo do usuário.
        /// </summary>
        public string NomeCompleto { get; set; }

        /// <summary>
        /// Altura do usuário.
        /// </summary>
        public decimal Altura { get; set; }

        /// <summary>
        /// Peso do usuário.
        /// </summary>
        public decimal Peso { get; set; }

        /// <summary>
        /// Data de nascimento do usuário.
        /// </summary>
        public DateTimeOffset DataNascimento { get; set; }

        /// <summary>
        /// Data de inclusão do usuário no sistema.
        /// </summary>
        public DateTimeOffset DataInclusao { get; set; }

        /// <summary>
        /// Flag identificadora de exclusão lógica do usuário.
        /// </summary>
        public bool Excluido { get; set; }

        /// <summary>
        /// Propriedade de navegação para as refeições do usuário.
        /// </summary>
        public virtual IEnumerable<DTODeRefeicao> Refeicoes { get; set; }
    }
}