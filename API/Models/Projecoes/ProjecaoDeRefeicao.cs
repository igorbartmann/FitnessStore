using System;

namespace FitnessStore.API.Models.Projecoes
{
    public class ProjecaoDeRefeicao
    {
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
    }
}