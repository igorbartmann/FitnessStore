using System;

namespace DevFitness.ConsoleApp.Usuarios
{
    public class Usuario
    {
        #region Atributos

        public string Nome { get; private set; }
        public string Cpf { get; private set; }
        public int Idade { get; private set; }
        public char Sexo { get; private set; }
        public double Altura { get; private set; }
        public double Peso { get; private set; }

        #endregion

        /// <summary>
        /// Construtor da classe que recebe nome, idade, sexo, altura e peso do usuário.
        /// </summary>
        /// <param name="nome">Nome do usuário</param>
        /// <param name="idade">Idade do usuário</param>
        /// <param name="sexo">Sexo do usuário</param>
        /// <param name="altura">Altura do usuário</param>
        /// <param name="peso">Peso do usuário</param>
        public Usuario(string nome, int idade, char sexo, double altura, double peso)
        {
            this.Nome = nome;
            this.Cpf = null;
            this.Idade = idade;
            this.Sexo = sexo;
            this.Altura = altura;
            this.Peso = peso;
        }

        /// <summary>
        /// Construtor da classe que recebe nome, cpf, idade, sexo, altura e peso do usuário.
        /// </summary>
        /// <param name="nome">Nome do usuário</param>
        /// <param name="cpf">CPF do usuário</param>
        /// <param name="idade">Idade do usuário</param>
        /// <param name="sexo">Sexo do usuário</param>
        /// <param name="altura">Altura do usuário</param>
        /// <param name="peso">Peso do usuário</param>
        public Usuario(string nome, string cpf, int idade, char sexo, double altura, double peso)
        {
            this.Nome = nome;
            this.Cpf = cpf;
            this.Idade = idade;
            this.Sexo = sexo;
            this.Altura = altura;
            this.Peso = peso;
        }

        #region Métodos setters

        /// <summary>
        /// Alteurar o nome do usuário.
        /// </summary>
        /// <param name="nome">Nome do usuário</param>
        public void SetNome(string nome)
        {
            this.Nome = nome;
        }

        /// <summary>
        /// Alterar o CPF do usuário.
        /// </summary>
        /// <param name="cpf">CPF do usuário</param>
        public void SetCpf(string cpf)
        {
            this.Cpf = cpf;
        }

        /// <summary>
        /// Alterar a idade do usuário.
        /// </summary>
        /// <param name="idade">Idade do usuário</param>
        public void SetIdade(int idade)
        {
            this.Idade = idade;
        }

        /// <summary>
        /// Alterar o sexo do usuário.
        /// </summary>
        /// <param name="sexo">Sexo do usuário</param>
        public void SetSexo(char sexo)
        {
            this.Sexo = sexo;
        }

        /// <summary>
        /// Alterar a altura do usuário.
        /// </summary>
        /// <param name="altura">Altura do usuário</param>
        public void SetAltura (double altura)
        {
            this.Altura = altura;
        }

        /// <summary>
        /// Alterar o peso do usuário.
        /// </summary>
        /// <param name="peso">Peso do usuário</param>
        public void SetPeso(double peso)
        {
            this.Peso = peso;
        }

        #endregion

        /// <summary>
        ///  Obter as informações do usuário.
        /// </summary>
        /// <returns>String com as informações do usuário</returns>
        public string ObterInformacoes()
        {
            return $"Nome: {this.Nome}.\n" +
                (this.Cpf != null ? $"Cpf: {this.Cpf}.\n" : string.Empty) +
                $"Idade: {this.Idade} anos.\n" +
                $"Sexo: {this.Sexo}.\n" +
                $"Altura: {this.Altura} metro(s)." +
                $"Peso: {this.Peso} Kg.\n";
        }
    }
}