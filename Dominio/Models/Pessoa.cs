using System;

namespace Dominio.Models
{
    public class Pessoa : EntidadeBase
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public DateTime DataNascimento { get; set; }

        public int ContatoID { get; set; }
        public Contato Contato { get; set; }
        public int EnderecoID { get; set; }
        public Endereco Endereco { get; set; }
    }
}
