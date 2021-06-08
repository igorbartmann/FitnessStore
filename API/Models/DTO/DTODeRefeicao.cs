using System;

namespace FitnessStore.API.Models.DTO
{
    /// <summary>
    /// DTO das refeições do sistema.
    /// </summary>
    public class DTODeRefeicao
    {
        /// <summary>
        /// Código identificador da refeição.
        /// </summary>
        public int CodigoRefeicao { get; set; }

        /// <summary>
        /// Descrição da refeição.
        /// </summary>
        public string Descricao { get; set; }

        /// <summary>
        /// Total de calorias fornecidos pela refeição.
        /// </summary>
        public int Calorias { get; set; }

        /// <summary>
        /// Data na qual a refeição foi realizada.
        /// </summary>
        public DateTimeOffset DataRealizada { get; set; }

        /// <summary>
        /// Data de inclusão da refeição no sistema.
        /// </summary>
        public DateTimeOffset DataInclusao { get; set; }

        /// <summary>
        /// Flag identificador de exclusão lógica da refeição.
        /// </summary>
        public bool Excluido { get; set; }

        /// <summary>
        /// Codigo identificador do usuário ao qual a refeição pertence.
        /// </summary>
        public int CodigoUsuario { get; set; }

        /// <summary>
        /// Propriedade de navegação do usuário ao qual a refeição pertence.
        /// </summary>
        public virtual DTODeUsuario Usuario { get; set; }
    }
}