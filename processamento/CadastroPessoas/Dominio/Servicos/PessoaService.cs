using CadastroPessoas.Dominio.Servicos.Interfaces;
using CadastroPessoas.Repositorios.Interfaces;
using Dominio.Models;
using System;
using System.Collections.Generic;

namespace CadastroPessoas.Dominio.Servicos
{
    public class PessoaService : IPessoaService
    {
        #region campos
        private readonly IPessoaRepository pessoaRepo;
        private readonly string pessoaCadastrada = "A pessoa já esta cadastrada!";
        private readonly string pessoaNaoCadastrada = "A pessoa não esta cadastrada!";
        #endregion campos

        #region construtores
        public PessoaService(IPessoaRepository pessoaRepo)
        {
            this.pessoaRepo = pessoaRepo;
        }
        #endregion construtores

        #region métodos
        public Pessoa BuscarPor(int id)
        {
            try
            {
                return pessoaRepo.BuscarPor(id) ?? new Pessoa();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Pessoa Criar(Pessoa pessoa, ref string mensagem)
        {
            try
            {
                pessoa.Valida();
                pessoa.Endereco.Valida();

                if (pessoaRepo.Exists(pessoa.CPF))
                    throw new ArgumentException(pessoaCadastrada);

                return pessoaRepo.Criar(pessoa);
            }
            catch (Exception ex)
            {
                mensagem = ex.Message;
                return null;
            }
        }

        public Pessoa Editar(Pessoa pessoa, ref string mensagem)
        {
            try
            {
                pessoa.Valida();
                pessoa.Endereco.Valida();

                if (!pessoaRepo.Exists(pessoa.Id))
                    throw new ArgumentException(pessoaNaoCadastrada);

                return pessoaRepo.Editar(pessoa);
            }
            catch (Exception ex)
            {
                mensagem = ex.Message;
                return null;
            }
        }

        public bool Excluir(int id, ref string mensagem)
        {
            try
            {
                if (!pessoaRepo.Exists(id))
                    throw new ArgumentException(pessoaNaoCadastrada);

                pessoaRepo.Excluir(id);

                return true;
            }
            catch (Exception ex)
            {
                mensagem = ex.Message;
                return false;
            }
        }

        public List<Pessoa> Listar(ref string mensagem)
        {
            try
            {
                return pessoaRepo.Listar();
            }
            catch (Exception ex)
            {
                mensagem = ex.Message;
                return null;
            }
        }
        #endregion métodos
    }
}
