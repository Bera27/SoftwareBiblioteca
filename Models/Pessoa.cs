using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftwareBiblioteca.Models
{
    public class Pessoa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
        public string LivroAlugado { get; set; }
        public DateTime DataAluguel { get; set; }
        public DateTime DataDevolucao { get; set; }
    }
}