using System;

namespace DevFitness.ConsoleApp.Refeicoes
{
    public class Comida : Refeicao
    {
        #region Atributos

        public double Peso { get; set; }

        #endregion

        /// <summary>
        /// Construtor da classe vazío;
        /// </summary>
        public Comida() : base() { }

        #region Construtores extras

        /// <summary>
        /// Construtor da classe recebendo descricao, calorias e peso.
        /// </summary>
        /// <param name="descricao">Descrição da comida</param>
        /// <param name="calorias">Total de calorias fornecidas pela comida</param>
        /// <param name="peso">Peso da comida em Kg</param>
        public Comida(string descricao, int calorias, double peso) : base(descricao, calorias)
        {
            this.Peso = peso;
        }

        /// <summary>
        /// Construtor da classe recebendo descricao, calorias, preso e peso.
        /// </summary>
        /// <param name="descricao">Descrição da comida</param>
        /// <param name="calorias">Total de calorias fornecidas pela comida</param>
        /// <param name="peso">Peso da comida em Kg</param>
        /// <param name="preco">Preço da comida</param>
        public Comida(string descricao, int calorias, double peso, decimal preco) : base(descricao, calorias, preco)
        {
            this.Peso = peso;
        }

        #endregion

        #region Métodos setters

        /// <summary>
        /// Alterar o peso da comida.
        /// </summary>
        /// <param name="peso">Novo peso da comida em Kg</param>
        public void SetPeso(double peso)
        {
            this.Peso = peso;
        }

        #endregion

        /// <summary>
        /// Obter as informações da comida.
        /// </summary>
        /// <returns>String com os detalhes da comida</returns>
        public override string ObterInformacoes()
        {
            return $"Descricao: {this.Descricao}.\n" +
                $"Calorias: {this.Calorias}.\n" +
                $"Peso: {this.Peso}Kg.\n" +
                $"Preço: R$ {this.Preco.ToString("F2")}.\n";
        }
    }
}