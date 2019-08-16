using System;
using System.Text.RegularExpressions;

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

        #region métodos
        public void Merge(Pessoa novaPessoa)
        {
            Nome = novaPessoa.Nome ?? Nome;
            DataNascimento = novaPessoa.DataNascimento;

            Contato.Celular = novaPessoa.Contato.Celular;
            Contato.Telefone = novaPessoa.Contato.Telefone;
            Contato.Email = novaPessoa.Contato.Email;

            Endereco.Bairro = novaPessoa.Endereco.Bairro;
            Endereco.CEP = novaPessoa.Endereco.CEP;
            Endereco.Cidade = novaPessoa.Endereco.Cidade;
            Endereco.Complemento = novaPessoa.Endereco.Complemento;
            Endereco.DataAlteracao = DateTime.Now;
            Endereco.Estado = novaPessoa.Endereco.Estado;
            Endereco.Logradouro = novaPessoa.Endereco.Logradouro;
            Endereco.Numero = novaPessoa.Endereco.Numero;
            Endereco.Pais = novaPessoa.Endereco.Pais;
        }

        public void Valida()
        {
            ValidaCPF();

            if (string.IsNullOrWhiteSpace(Nome) || Nome.Length < 3 || Nome.Length > 255)
                throw new ArgumentException("Nome inválido");
        }

        private void ValidaCPF()
        {
            var regex = new Regex("^[0-9]{11}$");

            CPF = (CPF != null) ? CPF = CPF.Replace("-", "").Replace(".", "") : string.Empty;

            if (CPF.Length != 11 || !regex.IsMatch(CPF))
                throw new ArgumentException("CPF Inválido");
        }
        #endregion métodos
    }
}
