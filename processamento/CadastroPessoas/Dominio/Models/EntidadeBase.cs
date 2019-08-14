using System;

namespace Dominio.Models
{
    public abstract class EntidadeBase : IEntidadeBase
    {
        public int Id { get; set; }
        public bool IsAtivo { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataAlteracao { get; set; }
    }
}
