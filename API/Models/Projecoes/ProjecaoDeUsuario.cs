using System;

namespace FitnessStore.API.Models.Projecoes
{
    public class ProjecaoDeUsuario
    {
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
    }
}