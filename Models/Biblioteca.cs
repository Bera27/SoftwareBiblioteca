using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftwareBiblioteca.Models
{
    public class Biblioteca
    {
        private List<Livro> livros = new List<Livro>();
        private List<Pessoa> pessoas = new List<Pessoa>();


        public void LimparConsole()
        {
            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
        }

        public void AdicionarLivro()
        {
            Console.WriteLine("Insira o Nome do Livro:");
            string nome = Console.ReadLine();

            Console.WriteLine("Insira o Autor:");
            string autor = Console.ReadLine();

            Console.WriteLine("O Livro vai pode ser alugado: Sim/Não");
            string resposta = Console.ReadLine().ToUpper();

            bool aluga = resposta.Equals("SIM", StringComparison.CurrentCultureIgnoreCase) || resposta.Equals("S", StringComparison.CurrentCultureIgnoreCase); // Torna a resposta um bool true ou false

            Console.WriteLine("Adicione o Preço da Venda do Livro:");
            decimal precoVenda = decimal.Parse(Console.ReadLine());

            decimal precoAluguel = 0;

            if (aluga == true)  // verifica se o livro pode ser alugado
            {
                Console.WriteLine("Adicione o Preço do Aluguel do Livro:");
                precoAluguel = decimal.Parse(Console.ReadLine());
            }

            Console.WriteLine("Adicione a Quantidade do Livro em Estoque:");
            int quantidade = int.Parse(Console.ReadLine());

            var novoLivro = new Livro()
            {
                Titulo = nome,
                Autor = autor,
                PrecoVenda = precoVenda,
                PrecoAluguel = precoAluguel,
                Quantidade = quantidade,
                Aluga = aluga
            };


            livros.Add(novoLivro);

            Console.WriteLine($"Livro Cadastrado com Sucesso!");
            LimparConsole();

        }

        public void AlugarLivro()
        {
            Console.WriteLine("Qual Livro deseja Alugar:");
            string BuscaLivro = Console.ReadLine();

            var livroEncontrado = livros.FirstOrDefault(p => p.Titulo.Equals(BuscaLivro, StringComparison.OrdinalIgnoreCase));  // Busca o Nome do livro

            if (livroEncontrado == null || livroEncontrado.Quantidade == 0)
            {
                Console.WriteLine("Livro Inexistente ou Fora de Estoque!");
                LimparConsole();
                return;
            }
            if (!livroEncontrado.Aluga)
            {
                Console.WriteLine("Livro Não Pode Ser Alugado!");
                LimparConsole();
                return;
            }

            Console.WriteLine($"Livro: {livroEncontrado.Titulo} | Autor: {livroEncontrado.Autor} | Preço do Aluguel {livroEncontrado.PrecoAluguel:C}");
            Console.WriteLine("Deseja conformar o aluguel? (Sim/Não)");
            string resposta = Console.ReadLine().ToUpper();

            if (resposta == "SIM" || resposta == "S")
            {
                CadastradoPessoa();

                livroEncontrado.Quantidade--;
                livroEncontrado.EstoqueLivrosAlugados++;
                Console.WriteLine("Aluguel realizado com sucesso!");
            }
        }

        public void CadastradoPessoa()
        {
            Console.WriteLine("Digite o Nome Completo da Pessoa:");
            string nome = Console.ReadLine().ToUpper();

            Console.WriteLine("Digite o Telefone da Pessoa:");
            string telefone = Console.ReadLine();

            Console.WriteLine("Digite o Endereço da Pessoa:");
            string endereco = Console.ReadLine().ToUpper();

            Console.WriteLine("Digite o Titulo do Livro Alugado:");
            string livroAlugado = Console.ReadLine().ToUpper();

            DateTime dataAluguel = DateTime.Now;   // Data que o livro foi alugado

            Console.WriteLine("Digite a Data de Devolução (dd/MM/yyyy):");
            DateTime dataDevolucao;
            while (!DateTime.TryParse(Console.ReadLine(), out dataDevolucao))
            {
                Console.WriteLine("Formato inválido! Digite novamente a data no formato dd/MM/yyyy:");
            }
            dataDevolucao = dataDevolucao.Date; // Remove o horário, mantendo apenas a data

            var novoAlguel = new Pessoa()
            {
                Nome = nome,
                Telefone = telefone,
                Endereco = endereco,
                LivroAlugado = livroAlugado,
                DataAluguel = dataAluguel,
                DataDevolucao = dataDevolucao,
            };

            pessoas.Add(novoAlguel);
            Console.WriteLine("Cadastro de Cliente Realizado com Sucesso!");

            LimparConsole();
        }

        public void ListarLivrosAlugados()
        {
            Console.Clear();
            Console.WriteLine("Lista das Pessoas com Livros Alugados:");

            if (pessoas.Count == 0)
            {
                Console.WriteLine("Nenhum livro alugado no momento.");
            }
            else
            {
            foreach (var item in pessoas)
                {
                    Console.WriteLine($"Nome: {item.Nome} | Telefone: {item.Telefone} | Endereço: {item.Endereco} | Livro: {item.LivroAlugado} | Data: {item.DataAluguel} | Devolução: {item.DataDevolucao}");
                }
            }

            LimparConsole();
        }

        public void BuscaLivro()
        {
            Console.WriteLine("Digite o Nome do Livro:");
            string buscaLivro = Console.ReadLine().ToUpper();

            var buscaFeita = livros.FirstOrDefault(p => p.Titulo.Equals(buscaLivro, StringComparison.OrdinalIgnoreCase));

            if (buscaFeita != null)
            {
                Console.WriteLine($"Titulo: {buscaFeita.Titulo} | Autor: {buscaFeita.Autor} | Preço: {buscaFeita.PrecoVenda:C} | Alugar: {buscaFeita.PrecoAluguel:C} | Quantidade: {buscaFeita.Quantidade}");
            }
            else
            {
                Console.WriteLine("Livro não encontrado!");
            }

            LimparConsole();
        }

        public void VendaLivro()
        {
            Console.WriteLine("Digite o nome do livro que deseja Vender:");
            string buscaLivro = Console.ReadLine().ToUpper();
            var buscaFeita = livros.FirstOrDefault(p => p.Titulo.Equals(buscaLivro, StringComparison.OrdinalIgnoreCase));          //Busca o livro

            if (buscaFeita == null || buscaFeita.Quantidade == 0)
            {
                Console.WriteLine("Livro inexistente ou fora do estoque!");
                LimparConsole();
                return;
            }

            Console.WriteLine($"Titulo: {buscaFeita.Titulo} | Autor: {buscaFeita.Autor} | Preço: {buscaFeita.PrecoVenda:C}");
            Console.WriteLine("Deseja confirmar a compra? (Sim/Não)");
            string resposta = Console.ReadLine().ToUpper();

            if (resposta == "SIM" || resposta == "S")
            {
                buscaFeita.Quantidade--;
                Console.WriteLine("Venda Feita com Sucesso!");
            }

            LimparConsole();
        }

        public void VerificarEstoque()
        {
            Console.Clear();
            Console.WriteLine("Estoque da biblioteca");

            if (!livros.Any())
            {
                Console.WriteLine("Nenhum livro cadastrado no estoque.");
            }
            else
            {
                foreach (var item in livros)
                {
                    Console.WriteLine($"Titulo: {item.Titulo} | Quantidade em Estoque: {item.Quantidade} | Valor em Estoque do Livro: {item.Quantidade * item.PrecoVenda:C}");
                    Console.WriteLine($"Livros Alugados: {item.EstoqueLivrosAlugados}");
                    Console.WriteLine("---------------------------");
                }
            }

            int estoqueTotal = livros.Sum(l => l.Quantidade);
            Console.WriteLine($"Estoque Total de livros: {estoqueTotal}");
            LimparConsole();
        }


    }
}