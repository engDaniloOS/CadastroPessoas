using Dominio.Models;
using System.Collections.Generic;

namespace CadastroPessoas.Dominio.Servicos.Interfaces
{
    public interface IPessoaService
    {
        Pessoa Criar(Pessoa pessoa, ref string mensagem);
        Pessoa BuscarPor(int id);
        List<Pessoa> Listar(ref string mensagem);
        Pessoa Editar(Pessoa pessoa, ref string mensagem);
        bool Excluir(int id, ref string mensagem);
    }
}
