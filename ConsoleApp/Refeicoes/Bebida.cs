using System;

namespace DevFitness.ConsoleApp.Refeicoes
{
    public class Bebida : Refeicao
    {
        #region Atributos

        public int Mililitros { get; private set; }

        #endregion

        /// <summary>
        /// Construtor da classe vazío.
        /// </summary>
        public Bebida() : base() { }

        #region Construtores extras

        /// <summary>
        /// Construtor da classe recebendo descrição, calorias e mililitros da bebida.
        /// </summary>
        /// <param name="descricao">Descrição da bebida</param>
        /// <param name="calorias">Total de calorias fornecidas pela bebida</param>
        /// <param name="mililitros">Quantidade de mililitros (ml) da bebida</param>
        public Bebida(string descricao, int calorias, int mililitros) : base(descricao, calorias)
        {
            this.Mililitros = mililitros;
        }

        /// <summary>
        /// Contrutor da classe recebendo descrição, calorias, mililitros e preço da bebida.
        /// </summary>
        /// <param name="descricao">Descrição da bebida</param>
        /// <param name="calorias">Total de calorias fornecidas pela bebida</param>
        /// <param name="mililitros">Quantidade de mililitros (ml) da bebida</param>
        /// <param name="preco">Preço da bebida</param>
        public Bebida(string descricao, int calorias, int mililitros, decimal preco) : base(descricao, calorias, preco)
        {
            this.Mililitros = mililitros;
        }

        #endregion

        #region Métodos setters

        /// <summary>
        /// Alterar a quantidade de militros (ml) da bebida.
        /// </summary>
        /// <param name="mililitros">Nova quantidade de mililitros (ml) da bebida</param>
        public void SetMililitros(int mililitros)
        {
            this.Mililitros = mililitros;
        }

        #endregion

        /// <summary>
        /// Obter as informações da bebida.
        /// </summary>
        /// <returns>String com os detalhes da bebida</returns>
        public override string ObterInformacoes()
        {
            return $"Descricao: {this.Descricao}.\n" +
                $"Calorias: {this.Calorias}.\n" +
                $"Mililitros: {this.Mililitros}ml.\n" +
                $"Preço: R$ {this.Preco.ToString("F2")}.\n";
        }
    }
}