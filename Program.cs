using SoftwareBiblioteca.Models;

Biblioteca biblioteca = new Biblioteca();

while (true)
{
    Console.WriteLine("1 - Cadastrar Livro");
    Console.WriteLine("2 - Alugar Livro");
    Console.WriteLine("3 - Vender Livro");
    Console.WriteLine("4 - Buscar Livro");
    Console.WriteLine("5 - Listar Livros Alugados");
    Console.WriteLine("6 - Verificar Estoque");
    Console.WriteLine("7 - Sair");

    int resposta = int.Parse(Console.ReadLine());

    switch (resposta)
    {
        case 1:
            biblioteca.AdicionarLivro();
            break;

        case 2:
            biblioteca.AlugarLivro();
            break;

        case 3:
            biblioteca.VendaLivro();
            break;

        case 4:
            biblioteca.BuscaLivro();
            break;

        case 5:
            biblioteca.ListarLivrosAlugados();
            break;

        case 6:
            biblioteca.VerificarEstoque();
            break;



        default:
            Console.WriteLine("Opeção inválida! Tente novamente.");
            break;
    }
}