using System;

namespace Dominio.Models
{
    public interface IEntidadeBase
    {
        DateTime DataAlteracao { get; set; }
        DateTime DataCriacao { get; set; }
        int Id { get; set; }
        bool IsAtivo { get; set; }
    }
}