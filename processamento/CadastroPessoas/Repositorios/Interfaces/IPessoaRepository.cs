using Dominio.Models;
using System.Collections.Generic;

namespace CadastroPessoas.Repositorios.Interfaces
{
    public interface IPessoaRepository
    {
        Pessoa Criar(Pessoa pessoa);
        Pessoa BuscarPor(int id);
        List<Pessoa> Listar();
        bool Exists(string cpf);
        bool Exists(int id);
        Pessoa Editar(Pessoa pessoa);
        void Excluir(int id);
    }
}
