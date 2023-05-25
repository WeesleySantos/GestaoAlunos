using GestaoDeTurmas.API.Repositorios;
using GestaoDeTurmas.WEB.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GestaoTurma.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CadastroTurmaController : ControllerBase
    {
        private readonly ICadastroTurmaDB _turmaDB;

        public CadastroTurmaController(ICadastroTurmaDB turmaDB)
        {
            _turmaDB = turmaDB;
        }

        [HttpPost]
        [Route("cadastrarturma")]
        public async Task<IActionResult> CadastroTurma([FromBody]CadastroTurmaModel turma)
        {
            var resposta = await _turmaDB.Cadastrar(turma);
            if (resposta is true) return Ok("Turma cadastrada com sucesso!");
            return BadRequest("Não foi possivel cadastrar a turma");
        }

        [HttpGet]
        [Route("listaturmas")]

        public async Task<IActionResult> GetTurmas()
        {
            var resposta = await _turmaDB.ListaTurmas();
            if (resposta != null) return Ok(resposta);
            return BadRequest("Não foi possivel encontrar as turmas");
        }

        [HttpGet]
        [Route("turmaporid/{id}")]
        public async Task<IActionResult> GetAlunoPorId(int id)
        {
            var resposta = await _turmaDB.CarregaTurmaPorId(id);
            if (resposta != null) return Ok(resposta);
            return BadRequest("Cadastro não encontrado");
        }

        [HttpPut]
        [Route("Atualizarturma")]
        public async Task<IActionResult> AtualizarTurma([FromBody] CadastroTurmaModel turma)
        {
            var resposta = await _turmaDB.Atualizar(turma);
            if (resposta is true) return Ok("Turma atualizada com sucesso!");
            return BadRequest("Não foi possivel atualizar a turma");
        }
    }
}
