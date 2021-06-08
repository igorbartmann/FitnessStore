using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitnessStore.API.Core.Entities
{
    /// <summary>
    /// Tabela das refeições do sistema.
    /// </summary>
    [Table("Refeicoes")]
    public class Refeicao
    {
        /// <summary>
        /// Código identificador da refeição.
        /// </summary>
        [Column("CODIGOREFEICAO"), Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CodigoRefeicao { get; set; }

        /// <summary>
        /// Descrição da refeição.
        /// </summary>
        [Column("DESCRICAO"), Required, MaxLength(150, ErrorMessage = "A descrição da refeição deve conter no máximo 150 caracteres.")]
        public string Descricao { get; set; }

        /// <summary>
        /// Total de calorias fornecidos pela refeição.
        /// </summary>
        [Column("CALORIAS"), Required]
        public int Calorias { get; set; }

        /// <summary>
        /// Data na qual a refeição foi realizada.
        /// </summary>
        [Column("DATAREALIZADA"), Required]
        public DateTimeOffset DataRealizada { get; set; }

        /// <summary>
        /// Data de inclusão da refeição no sistema.
        /// </summary>
        [Column("DATAINCLUSAO"), Required]
        public DateTimeOffset DataInclusao { get; set; }

        /// <summary>
        /// Flag identificador de exclusão lógica da refeição.
        /// </summary>
        [Column("EXCLUIDO"), Required]
        public bool Excluido { get; set; }

        /// <summary>
        /// Codigo identificador do usuário ao qual a refeição pertence.
        /// </summary>
        [Column("CODIGOUSUARIO"), Required]
        public int CodigoUsuario { get; set; }

        /// <summary>
        /// Propriedade de navegação do usuário ao qual a refeição pertence.
        /// </summary>
        public virtual Usuario Usuario { get; set; }
    }
}