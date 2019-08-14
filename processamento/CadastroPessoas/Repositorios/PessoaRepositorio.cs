using CadastroPessoas.Repositorios.Interfaces;
using Dominio.Models;
using Infraestrutura;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CadastroPessoas.Repositorios
{
    public class PessoaRepositorio : IPessoaRepository
    {
        #region campos
        private readonly Contexto contexto;
        #endregion campos

        #region construtores
        public PessoaRepositorio(Contexto contexto)
        {
            this.contexto = contexto;
        }
        #endregion construtores

        #region métodos
        public Pessoa BuscarPor(int id)
        {
            var resultado = contexto.Pessoas
                                    .Include(p => p.Contato)
                                    .Include(p => p.Endereco)
                                    .Where(p => p.IsAtivo && p.Id == id)
                                    .ToList();

            return resultado.Count > 0 ? resultado.FirstOrDefault() : null;
        }

        public Pessoa Criar(Pessoa pessoa)
        {
            pessoa.IsAtivo = true;
            pessoa.DataCriacao = DateTime.Now;
            pessoa.DataAlteracao = pessoa.DataCriacao;

            pessoa.Endereco.IsAtivo = true;
            pessoa.Endereco.DataCriacao = pessoa.DataCriacao;
            pessoa.Endereco.DataAlteracao = pessoa.DataCriacao;

            pessoa.Contato.IsAtivo = true;
            pessoa.Contato.DataCriacao = pessoa.DataCriacao;
            pessoa.Contato.DataAlteracao = pessoa.DataCriacao;

            contexto.Add(pessoa);
            contexto.SaveChanges();

            return pessoa;
        }

        public List<Pessoa> Listar()
            => contexto.Pessoas
                       .Include(p => p.Contato)
                       .Include(p => p.Endereco)
                       .Where(p => p.IsAtivo)
                       .ToList();

        public Pessoa Editar(Pessoa pessoa)
        {
            var pessoaCadastrada = contexto.Pessoas
                                           .Include(p => p.Contato)
                                           .Include(p => p.Endereco)
                                           .Where(p => p.IsAtivo && p.Id == pessoa.Id)
                                           .ToList().FirstOrDefault();

            pessoaCadastrada.Merge(pessoa);

            contexto.Pessoas.Update(pessoaCadastrada);
            contexto.SaveChanges();

            return pessoaCadastrada;
        }

        public void Excluir(int id)
        {
            var pessoa = contexto.Pessoas
                                 .Include(p => p.Contato)
                                 .Include(p => p.Endereco)
                                 .Where(p => p.Id == id && p.IsAtivo)
                                 .ToList().FirstOrDefault();

            pessoa.IsAtivo = false;
            pessoa.Endereco.IsAtivo = false;
            pessoa.Contato.IsAtivo = false;

            contexto.Pessoas.Update(pessoa);

            contexto.SaveChanges();
        }

        public bool Exists(int id)
            => contexto.Pessoas.Where(p => p.Id == id && p.IsAtivo).ToList().Count > 0 ? true : false;
        
        public bool Exists(string cpf)
            => contexto.Pessoas.Where(p => p.IsAtivo && p.CPF == cpf).ToList().Count > 0 ? true : false;
        #endregion métodos
    }
}
