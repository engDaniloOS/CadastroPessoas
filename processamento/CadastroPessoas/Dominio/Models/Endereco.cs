using System;
using System.Text.RegularExpressions;

namespace Dominio.Models
{
    public class Endereco : EntidadeBase
    {
        public int Numero { get; set; }
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

            CEP = (CEP != null) ? CEP = CEP.Replace("-", "").Replace(".", "") : string.Empty;

            if (CEP.Length != 8 || !regex.IsMatch(CEP))
                throw new ArgumentException("CEP Inválido");
        }
    }
}
