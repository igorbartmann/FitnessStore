using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitnessStore.API.Core.Entities
{
    /// <summary>
    /// Tabela de usuarios do sistema.
    /// </summary>
    [Table("Usuarios")]
    public class Usuario
    {
        /// <summary>
        /// Construtor da classe.
        /// </summary>
        public Usuario()
        {
            Refeicoes = new List<Refeicao>();
        }

        /// <summary>
        /// Código identificador do usuário.
        /// </summary>
        [Column("CODIGOUSUARIO"), Key, Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CodigoUsuario { get; set; }

        /// <summary>
        /// Nome completo do usuário.
        /// </summary>
        [Column("NOMECOMPLETO"), Required, MaxLength(100, ErrorMessage = "O nome completo do usuário deve conter no máximo 100 caracteres.")]
        public string NomeCompleto { get; set; }

        /// <summary>
        /// Altura do usuário.
        /// </summary>
        [Column("ALTURA"), Required]
        public decimal Altura { get; set; }

        /// <summary>
        /// Peso do usuário.
        /// </summary>
        [Column("PESO"), Required]
        public decimal Peso { get; set; }

        /// <summary>
        /// Data de nascimento do usuário.
        /// </summary>
        [Column("DATANASCIMENTO"), Required]
        public DateTimeOffset DataNascimento { get; set; }

        /// <summary>
        /// Data de inclusão do usuário no sistema.
        /// </summary>
        [Column("DATAINCLUSAO"), Required]
        public DateTimeOffset DataInclusao { get; set; }

        /// <summary>
        /// Flag identificadora de exclusão lógica do usuário.
        /// </summary>
        [Column("EXCLUIDO"), Required]
        public bool Excluido { get; set; }

        /// <summary>
        /// Propriedade de navegação para as refeições do usuário.
        /// </summary>
        public virtual IEnumerable<Refeicao> Refeicoes { get; set; }
    }
}