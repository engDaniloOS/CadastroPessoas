using System.ComponentModel.DataAnnotations;

namespace Dominio.Models
{
    public class Contato : EntidadeBase
    {
        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string Celular { get; set; }

        [Phone]
        public string Telefone { get; set; }
    }
}
