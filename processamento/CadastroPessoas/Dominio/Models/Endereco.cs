using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Dominio.Models
{
    public class Endereco : EntidadeBase
    {
        [Required]
        public int Numero { get; set; }

        [Required, StringLength(10)]
        public string CEP { get; set; }

        public string Logradouro { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Pais { get; set; }

        public void Valida()
        {
            var regex = new Regex("^[0-9]{8}$");
            CEP = CEP.Replace("-", "").Replace(".", "");

            if (!regex.IsMatch(CEP))
                throw new ArgumentException("CEP Inválido");
        }
    }
}
