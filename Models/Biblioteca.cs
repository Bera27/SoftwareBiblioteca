using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftwareBiblioteca.Models
{
    public class Biblioteca
    {
        List<Livro> livros = new List<Livro>();
        List<Pessoa> pessoas = new List<Pessoa>();


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

            Console.Clear();


            Console.WriteLine("O Livro vai pode ser alugado: Sim/Não");
            string resposta = Console.ReadLine().ToUpper();

            bool aluga = resposta.Equals("SIM", StringComparison.CurrentCultureIgnoreCase) || resposta.Equals("S", StringComparison.CurrentCultureIgnoreCase); // Torna a resposta um bool true ou false

            Console.Clear();

            Console.WriteLine("Adicione o Preço da Venda do Livro:");
            decimal precoVenda = decimal.Parse(Console.ReadLine());

            decimal precoAluguel = 0;

            if (aluga == true)  // verifica se o livro pode ser alugado
            {
                Console.WriteLine("Adicione o Preço do Aluguel do Livro:");
                precoAluguel = decimal.Parse(Console.ReadLine());
            }

            Console.Clear();

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

            Console.WriteLine("Livro Cadastrado com Sucesso!");
            LimparConsole();

        }

        public void AlugarLivro()
        {
            Console.WriteLine("Qual Livro deseja Alugar:");
            string BuscaLivro = Console.ReadLine();

            var livroEncontrado = livros.FirstOrDefault(p => p.Titulo.Equals(BuscaLivro, StringComparison.OrdinalIgnoreCase));  // Busca o Nome do livro

            if (livroEncontrado == null)
            {
                Console.WriteLine("Livro Inexistente ou Fora de Estoque!");
                return;
            }
            if (livroEncontrado.Aluga == false)
            {
                Console.WriteLine("Livro Não Pode Ser Alugado!");
            }
            else
            {
                Console.WriteLine($"Livro: {livroEncontrado.Titulo} | Autor: {livroEncontrado.Autor} | Preço do Aluguel {livroEncontrado.PrecoAluguel:C}");
            }
        }

        public void CadastradoPessoa()
        {
            Console.WriteLine("Digite o Nome da Pessoa:");
            string nome = Console.ReadLine().ToUpper();

            Console.WriteLine("Digite o Telefone da Pessoa:");
            string telefone = Console.ReadLine();

            Console.Clear();

            Console.WriteLine("Digite o Endereço da Pessoa:");
            string endereco = Console.ReadLine().ToUpper();

            Console.WriteLine("Digite o Titulo do Livro Alugado:");
            string livroAlugado = Console.ReadLine().ToUpper();

            Console.Clear();

            Console.WriteLine("Digite a Data que o Livro foi Alugado:");
            DateTime dataAluguel = DateTime.Now;

            Console.WriteLine("Digite a Data de Devolução:");
            string dataDevolucao = Console.ReadLine();

            var novoAlguel = new Pessoa()
            {
                Nome = nome,
                Telefone = telefone,
                Endereco = endereco,
                LivroAlugado = livroAlugado,
                DataAluguel = dataAluguel,
                DataDevolucao = dataDevolucao
            };

            pessoas.Add(novoAlguel);
            Console.WriteLine("Cadastro de Cliente Realizado com Sucesso!");

            LimparConsole();
        }

        public void ListarLivrosAlgados()
        {
            Console.Clear();
            Console.WriteLine("Lista das Pessoas com Livros Alugados:");

            foreach (var item in pessoas)
            {
                Console.WriteLine($"Nome: {item.Nome} | Telefone: {item.Telefone} | Endereço: {item.Endereco} | Livro: {item.LivroAlugado} | Data: {item.DataAluguel} | Devolução: {item.DataDevolucao}");
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
        }
    }
}