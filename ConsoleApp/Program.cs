using System;
using System.Collections.Generic;
using DevFitness.ConsoleApp.Usuarios;
using DevFitness.ConsoleApp.Refeicoes;
using System.Linq;

namespace DevFitness.ConsoleApp
{
    public class Program
    {
        #region Constantes

        private const string ERROR_ADMIN_MESSAGE = "Erro! Contate o administrador do sistema.";
        private const string FORMAT_MESSAGE_ERROR = "Erro! Formato da entrada inválido.";
        private const string INVALID_MESSAGE_ERROR = "Erro! Valor da entrada inválido.";
        private const string QUESTION_MENU_MESSAGE = "Digite o valor corresponde à opção desejada: ";

        #endregion

        public static void Main(string[] args)
        {
            #region Variáveis de execução

            int option;
            bool executar = true;
            var refeicoes = new List<Refeicao>();

            #endregion

            Console.WriteLine(("--- Seja bem-vindo (a) ---\n\n").PadLeft(45) +
                "Antes de começar, precisamos de alguns dados..");

            Usuario usuario = CadastrarUsuario();

            while (executar)
            {
                option = ExibirMenuPrinciapal();
                ExecutarOpcaoSelecionada(option, usuario, refeicoes, out executar);
            }

            Console.Write("\nFechando o aplicativo...");
            System.Threading.Thread.Sleep(2500);
        }

        #region Métodos auxiliares

        /// <summary>
        /// Método que retorna o texto do menu principal da aplicação.
        /// </summary>
        private static int ExibirMenuPrinciapal()
        {
            Console.Clear();
            Console.WriteLine(($"--- Seja bem-vindo (a) ao DevFitness ---\n\n").PadLeft(50) +
                $"[1] - Cadastrar nova refeição.\n" +
                $"[2] - Buscar refeição.\n" +
                $"[3] - Excluir refeição.\n" +
                $"[4] - Listar todas refeições.\n" +
                $"[0] - Fechar o aplicativo.\n");

            return ValidarEntradaInt(QUESTION_MENU_MESSAGE, 4);
        }

        /// <summary>
        /// Método que retorna o tipo de refeição selecionado pelo usuário.
        /// </summary>
        /// <returns></returns>
        private static int MenuTipoRefeicao()
        {
            Console.WriteLine(("Tipos de Refeição disponíveis:\n").PadLeft(35) +
                "[1] - Bebida\n" +
                "[2] - Comida\n");

            return ValidarEntradaInt(QUESTION_MENU_MESSAGE, 2, 1);
        }

        /// <summary>
        /// Método para executar a opção selecionada pelo usuário.
        /// </summary>
        /// <param name="opcao">Opção selecionada pelo usuário</param>
        /// <param name="executar"></param>
        private static void ExecutarOpcaoSelecionada(int opcao, Usuario usuario, IList<Refeicao> refeicoes, out bool executar)
        {
            executar = true;

            Console.Clear();
            switch (opcao)
            {
                case 0: // Fechar o aplicativo
                    executar = false;
                    break;

                case 1: // Cadastrar nova refeição
                    Console.WriteLine(($"--- Cadastrar uma nova refeição para o(a) {usuario.Nome} ---\n").PadLeft(50));
                    var refeicaoCadastrada = CadastrarRefeicao(refeicoes);
                    if (refeicaoCadastrada != null)
                    {
                        Console.WriteLine($"Refeição cadastrada com sucesso, veja abaixo:\n\n{refeicaoCadastrada.ObterInformacoes()}");
                    }
                    else
                    {
                        Console.WriteLine("Erro ao cadastrar a refeição! A refeição já está cadastrada.");
                    }
                    break;

                case 2: // Buscar refeição
                    Console.WriteLine(("--- Buscar refeição ---\n").PadLeft(35));
                    var refeicaoBuscada = BuscarRefeicao(refeicoes);
                    if (refeicaoBuscada != null)
                    {
                        Console.WriteLine($"Refeição encontrada com sucesso, veja abaixo:\n\n{refeicaoBuscada.ObterInformacoes()}");
                    }
                    else
                    {
                        Console.WriteLine("Refeição não encontrada!");
                    }
                    break;

                case 3: // Excluir refeição
                    Console.WriteLine(("--- Excluir refeição ---\n").PadLeft(35));
                    var refeicaoDeletada = DeletarRefeicao(refeicoes);
                    if (refeicaoDeletada != null)
                    {
                        Console.WriteLine($"Refeição excluída com sucesso, veja abaixo:\n\n{refeicaoDeletada.ObterInformacoes()}");
                    }
                    else
                    {
                        Console.WriteLine("Erro ao excluir a refeição!");
                    }
                    break;

                case 4: // Listar todas refeições
                    Console.WriteLine(("--- Listar todas as refeições ---\n").PadLeft(45));
                    ListarRefeicoes(refeicoes);
                    break;

                default: // Erro (em um funcionamento correto, não deve cair aqui)
                    Console.WriteLine(ERROR_ADMIN_MESSAGE);
                    executar = false;
                    break;
            }

            if (opcao != 0)
            {
                Console.Write("\nTecle enter para voltar ao menu principal...");
                Console.ReadLine();
            }
        }

        /// <summary>
        /// Cadastrar um usuário
        /// </summary>
        /// <returns>Usuário cadastrado</returns>
        private static Usuario CadastrarUsuario()
        {
            string nome = string.Empty;
            while (nome.Length < 3)
            {
                Console.Write("Digite o seu nome: ");
                nome = Console.ReadLine().Trim();

                if (nome.Length < 3)
                {
                    Console.WriteLine(INVALID_MESSAGE_ERROR);
                }
            }


            string cpf = string.Empty;
            while (cpf.Length != 11)
            {
                Console.Write("Digite o seu CPF: ");
                cpf = Console.ReadLine().Trim();

                if (cpf.Length != 11)
                {
                    Console.WriteLine(INVALID_MESSAGE_ERROR);
                }
            }


            int idade = ValidarEntradaInt("Digite a sua idade: ", 140);

            int validacaoSexo = ValidarEntradaInt($"Sexo:\n" +
            $"[1] - Feminino\n" +
            $"[2] - Masculino\n" +
            $"{QUESTION_MENU_MESSAGE}", 2, 1);
            char sexo = validacaoSexo == 1 ? 'F' : 'M';

            double altura = 0;
            while (altura == 0)
            {
                Console.Write("Digite a sua altura: ");
                double.TryParse(Console.ReadLine().Replace('.', ','), out altura);

                if (altura == 0)
                {
                    Console.WriteLine(FORMAT_MESSAGE_ERROR);
                }
                else if (altura < 0 || altura > 3.5)
                {
                    Console.WriteLine(INVALID_MESSAGE_ERROR);
                    altura = 0;
                }
            }

            double peso = 0;
            while (peso == 0)
            {
                Console.Write("Digite o seu peso: ");
                double.TryParse(Console.ReadLine().Replace('.', ','), out peso);

                if (peso == 0)
                {
                    Console.WriteLine(FORMAT_MESSAGE_ERROR);
                }
                else if (peso < 0 || peso > 500)
                {
                    Console.WriteLine(INVALID_MESSAGE_ERROR);
                    peso = 0;
                }
            }

            return new Usuario(nome, idade, sexo, altura, peso);
        }

        /// <summary>
        /// Cadastrar uma refeição.
        /// </summary>
        /// <returns>Refeição cadastrada</returns>
        private static Refeicao CadastrarRefeicao(IList<Refeicao> refeicoes)
        {
            Refeicao refeicao;
            var tipoRefeicao = MenuTipoRefeicao();
            var tipoRefeicaoString = (tipoRefeicao == 1 ? "bebida" : "comida");

            Console.Write($"Dê um nome ou descrição para a {tipoRefeicaoString}: ");
            string descricao = Console.ReadLine().Trim();

            int calorias = ValidarEntradaInt($"Digite a quantidade total de calorias da {tipoRefeicaoString}: ");

            decimal preco = 0;
            while (preco == 0)
            {
                Console.Write($"Digite o preço da {tipoRefeicaoString}: ");
                decimal.TryParse(Console.ReadLine().Replace('.', ','), out preco);

                if (preco == 0)
                {
                    Console.WriteLine(FORMAT_MESSAGE_ERROR);
                }
            }

            switch (tipoRefeicao)
            {
                case 1: // Cadastrar Bebida
                    int mililitros = ValidarEntradaInt($"Digite a quantidade de mililitros (ml) da {tipoRefeicaoString}: ");
                    refeicao = new Bebida(descricao, calorias, mililitros, preco);
                    break;

                case 2: // Cadastrar Comida
                    double peso = 0;
                    while (peso == 0)
                    {
                        Console.Write($"Digite o peso da da {tipoRefeicaoString}: ");
                        double.TryParse(Console.ReadLine().Replace('.', ','), out peso);

                        if (peso == 0)
                        {
                            Console.WriteLine(FORMAT_MESSAGE_ERROR);
                        }
                    }

                    refeicao = new Comida(descricao, calorias, peso, preco);
                    break;

                default: // Erro (não pode cair aqui)
                    Console.WriteLine(ERROR_ADMIN_MESSAGE);
                    return null;
            }

            var refeicaoJaExiste = refeicoes
                .Any(r => r.Descricao == refeicao.Descricao
                    && r.Calorias == refeicao.Calorias
                    && r.Preco == refeicao.Preco);

            if (!refeicaoJaExiste)
            {
                refeicoes.Add(refeicao);
                return refeicao;
            }
            return null;
        }

        /// <summary>
        /// Buscar um refeição
        /// </summary>
        /// <param name="refeicoes">lista de refições do sistema</param>
        /// <returns>Refeição encontrada</returns>
        private static Refeicao BuscarRefeicao(IList<Refeicao> refeicoes)
        {
            Console.Write("Digite o nome ou descrição da refeição: ");
            string descricao = Console.ReadLine();

            decimal preco = 0;
            while (preco == 0)
            {
                Console.Write($"Digite o preço da refeição: ");
                decimal.TryParse(Console.ReadLine().Replace('.', ','), out preco);

                if (preco == 0)
                {
                    Console.WriteLine(FORMAT_MESSAGE_ERROR);
                }
            }

            return refeicoes
                .FirstOrDefault(r => r.Descricao.Equals(descricao, StringComparison.InvariantCultureIgnoreCase) && r.Preco == preco);
        }

        /// <summary>
        /// Deletar uma refeição
        /// </summary>
        /// <param name="refeicoes">Lista de refeições do sistema</param>
        /// <returns>Refeição deletada</returns>
        private static Refeicao DeletarRefeicao(IList<Refeicao> refeicoes)
        {
            Console.Write("Digite o nome ou descrição da refeição: ");
            string descricao = Console.ReadLine();

            decimal preco = 0;
            while (preco == 0)
            {
                Console.Write($"Digite o preço da refeição: ");
                decimal.TryParse(Console.ReadLine().Replace('.', ','), out preco);

                if (preco == 0)
                {
                    Console.WriteLine(FORMAT_MESSAGE_ERROR);
                }
            }

            var refeicao = refeicoes
                .FirstOrDefault(r => r.Descricao.Equals(descricao, StringComparison.InvariantCultureIgnoreCase) && r.Preco == preco);

            refeicoes.Remove(refeicao);
            return refeicao;
        }

        /// <summary>
        /// Listar todas as refeições.
        /// </summary>
        /// <param name="refeicoes">Lista de refeições do sistema</param>
        private static void ListarRefeicoes(IList<Refeicao> refeicoes)
        {
            if (!refeicoes.Any())
            {
                Console.WriteLine("Nennhuma refeição cadastrada!");
            }

            foreach (var refeicao in refeicoes)
            {
                if (refeicao.GetType() == typeof(Comida))
                {
                    Console.WriteLine(((Comida)refeicao).ObterInformacoes());
                }
                else if (refeicao.GetType() == typeof(Bebida))
                {
                    Console.WriteLine(((Bebida)refeicao).ObterInformacoes());
                }
                else
                {
                    Console.WriteLine(((Refeicao)refeicao).ObterInformacoes());
                }

                Console.WriteLine("\n");
            }
        }

        /// <summary>
        /// Método para validar a entrada e transformar de string para int.
        /// </summary>
        /// <param name="msg">Mensagem a ser exibida para o usuário</param>
        /// <param name="maxValue">Valor máximo aceito para resposta (opcional)</param>
        /// <param name="minValue">Valor mínimo aceiro para a resposta (opcional)</param>
        /// <returns>Entrada do usuário validada e convertida para int</returns>
        public static int ValidarEntradaInt(string msg, int maxValue = 0, int minValue = 0)
        {
            int escolha, validacao = minValue - 1;

            do
            {
                try
                {
                    Console.Write(msg);
                    escolha = Convert.ToInt32(Console.ReadLine());

                    if (minValue != maxValue && (escolha < minValue || escolha > maxValue))
                    {
                        throw new ArgumentException();
                    }

                }
                catch (FormatException)
                {
                    Console.WriteLine(FORMAT_MESSAGE_ERROR);
                    escolha = validacao;
                }
                catch (ArgumentException)
                {
                    Console.WriteLine(INVALID_MESSAGE_ERROR);
                    escolha = validacao;
                }
            } while (escolha == validacao);

            return escolha;
        }

        #endregion
    }
}