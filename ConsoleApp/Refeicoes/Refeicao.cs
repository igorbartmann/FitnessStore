using System;

namespace DevFitness.ConsoleApp.Refeicoes
{
    public class Refeicao
    {
        #region Atributos

        public string Descricao { get; private set; }
        public int Calorias { get; private set; }
        public decimal Preco { get; private set; }

        #endregion

        /// <summary>
        /// Construtor da classe vazío.
        /// </summary>
        public Refeicao() { }

        #region Construtores extras

        /// <summary>
        /// Construtor da classe recebendo descrição e calorias.
        /// </summary>
        /// <param name="descricao">Descrição da refeição</param>
        /// <param name="calorias">Total de calorias fornecidas pela refeição</param>
        public Refeicao(string descricao, int calorias)
        {
            this.Descricao = descricao;
            this.Calorias = calorias;
            this.Preco = 0;
        }

        /// <summary>
        /// Construtor da classe recebendo descrição, calorias e preço da refeição.
        /// </summary>
        /// <param name="descricao">Descrição da refeição</param>
        /// <param name="calorias">Total de calorias fornecidas pela refeição</param>
        /// <param name="preco">Preço da refeição</param>
        public Refeicao(string descricao, int calorias, decimal preco)
        {
            this.Descricao = descricao;
            this.Calorias = calorias;
            this.Preco = preco;
        }

        #endregion

        #region Métodos setters

        /// <summary>
        /// Alterar a descrição da refeição.
        /// </summary>
        /// <param name="descricao">Nova descrição para a refeição</param>
        public void SetDescricao(string descricao)
        {
            this.Descricao = descricao;
        }

        /// <summary>
        /// Alterar a quantidade de calorias da refeição.
        /// </summary>
        /// <param name="calorias">Nova quantidade de calorias da refeição</param>
        public void SetCalorias(int calorias)
        {
            this.Calorias = calorias;
        }

        /// <summary>
        /// Alterar o preço da refeição.
        /// </summary>
        /// <param name="preco">Novo preço da refeição</param>
        public void SetPreco(decimal preco)
        {
            this.Preco = preco;
        }

        #endregion

        /// <summary>
        /// Obter as informações da refeição.
        /// </summary>
        /// <returns>String com os detalhes da refeição</returns>
        public virtual string ObterInformacoes()
        {
            return $"Descricao: {this.Descricao}.\n" +
                $"Calorias: {this.Calorias}.\n" +
                $"Preço: R$ {this.Preco.ToString("F2")}.\n";
        }
    }
}