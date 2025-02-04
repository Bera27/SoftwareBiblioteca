using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftwareBiblioteca.Models
{
    public class Biblioteca
    {
        List<Livro> livros = new List<Livro>();

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

            Console.WriteLine("Adicione o Preço da Venda do Livro:");
            decimal precoVenda = decimal.Parse(Console.ReadLine());
            
            Console.WriteLine("Adicione o Preço do Aluguel do Livro:");
            decimal precoAluguel = decimal.Parse(Console.ReadLine());

            Console.Clear();

            Console.WriteLine("Adicione a Quantidade dos Livros em Estoque:");
            int quantidade = int.Parse(Console.ReadLine());

            Console.WriteLine("O Livro vai pode ser alugado: Sim/Não");
            string resposta = Console.ReadLine().ToUpper();

            bool aluga = resposta.Equals("SIM", StringComparison.CurrentCultureIgnoreCase) || resposta.Equals("S", StringComparison.CurrentCultureIgnoreCase);

            var novoLivro = new Livro()
            {
                Nome = nome,
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

            var livroEncontrado = livros.FirstOrDefault(p => p.Nome.Equals(BuscaLivro, StringComparison.OrdinalIgnoreCase));

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
                Console.WriteLine($"Livro: {livroEncontrado.Nome} | {livroEncontrado.Autor} | {livroEncontrado.PrecoAluguel}");
            }
        }
    }
}