using CadastroPessoas.Dominio.Servicos.Interfaces;
using Dominio.Models;
using Microsoft.AspNetCore.Mvc;

namespace CadastroPessoas.Controllers
{
    [ApiController]
    [Route("api/pessoa")]
    public class PessoaController : Controller
    {
        #region campos
        private readonly IPessoaService pessoaService;
        private readonly string msgBadRequest = "Não foi possível concluir a ação!";
        #endregion campos

        #region construtores
        public PessoaController(IPessoaService pessoaService)
        {
            this.pessoaService = pessoaService;
        }
        #endregion construtores

        #region métodos auxiliares
        private ActionResult MontaResultado(Pessoa pessoa, string mensagem = "")
        {
            if (pessoa == null)
                return BadRequest($"{msgBadRequest}Erro:{mensagem}");

            else if (pessoa.Id == 0)
                return NotFound();

            return Ok(pessoa);
        }
        #endregion métodos auxiliares

        #region métodos
        [HttpPost]
        public ActionResult CriarPessoa([FromBody] Pessoa pessoa)
        {
            var mensagem = string.Empty;
            return MontaResultado(pessoaService.Criar(pessoa, ref mensagem), mensagem);
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult BuscarPessoa(int id)
            => MontaResultado(pessoaService.BuscarPor(id));

        [HttpGet]
        public ActionResult ListarPessoas()
        {
            var mensagem = string.Empty;

            var pessoas = pessoaService.Listar(ref mensagem);

            if (pessoas == null)
                return BadRequest($"{msgBadRequest}Erro:{mensagem}");

            else if (pessoas.Count == 0)
                return NotFound();

            return Ok(pessoas);
        }

        [HttpPut]
        public ActionResult EditarPessoa([FromBody] Pessoa pessoa)
        {
            var mensagem = string.Empty;
            return MontaResultado(pessoaService.Editar(pessoa, ref mensagem), mensagem);
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult ExcluirPessoa(int id)
        {
            var mensagem = string.Empty;

            if (pessoaService.Excluir(id, ref mensagem))
                return NoContent();

            return BadRequest($"{msgBadRequest}Erro: {mensagem}");
        }
        #endregion métodos
    }
}
