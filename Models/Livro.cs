using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftwareBiblioteca.Models
{
    public class Livro
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public decimal PrecoVenda { get; set; }
        public decimal PrecoAluguel { get; set; }
        public int Quantidade { get; set; }
        public int EstoqueLivrosAlugados { get; set; }
        public bool Aluga { get; set; }
    }
}