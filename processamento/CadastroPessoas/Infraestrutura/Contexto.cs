using Dominio.Models;
using Microsoft.EntityFrameworkCore;

namespace Infraestrutura
{
    public class Contexto : DbContext
    {
        #region construtores
        public Contexto(DbContextOptions options) : base(options)
        {
        }
        #endregion construtores

        #region DbSet
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Contato> Contatos { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        #endregion DbSet

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            #region pessoa
            builder.Entity<Pessoa>().Property(q => q.Nome).HasMaxLength(255).IsRequired();
            builder.Entity<Pessoa>().Property(q => q.CPF).HasMaxLength(11).IsRequired();
            builder.Entity<Pessoa>().HasOne(q => q.Contato);
            builder.Entity<Pessoa>().HasOne(q => q.Endereco);
            #endregion pessoa

            #region endereco
            builder.Entity<Endereco>().Property(q => q.CEP).HasMaxLength(10).IsRequired();
            builder.Entity<Endereco>().Property(q => q.Numero).IsRequired();
            builder.Entity<Endereco>().Property(q => q.Complemento).HasMaxLength(255);
            builder.Entity<Endereco>().Property(q => q.Bairro).HasMaxLength(255);
            builder.Entity<Endereco>().Property(q => q.Cidade).HasMaxLength(255);
            builder.Entity<Endereco>().Property(q => q.Estado).HasMaxLength(255);
            builder.Entity<Endereco>().Property(q => q.Pais).HasMaxLength(255);
            #endregion endereco

            #region contato
            builder.Entity<Contato>().Property(q => q.Celular).HasMaxLength(20);
            builder.Entity<Contato>().Property(q => q.Telefone).HasMaxLength(20);
            builder.Entity<Contato>().Property(q => q.Email).HasMaxLength(255);
            #endregion contato
        }
    }
}
