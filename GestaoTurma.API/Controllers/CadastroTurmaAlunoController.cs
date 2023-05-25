using GestaoDeTurmas.WEB.Models;
using GestaoTurma.API.Repositorios;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GestaoTurma.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CadastroTurmaAlunoController : ControllerBase
    {
        private readonly ICadastroTurmaAlunoDB _turmaAlunoDB;

        public CadastroTurmaAlunoController(ICadastroTurmaAlunoDB turmaAlunoDB)
        {
            _turmaAlunoDB = turmaAlunoDB;
        }

        [HttpPost]
        [Route("cadastraralunoturma")]
        public async Task<IActionResult> Cadastro([FromBody] CadastroTurmaAlunoModel turmaAluno)
        {
            var resposta = await _turmaAlunoDB.CadastrarTurmaAluno(turmaAluno);
            if (resposta is true) return Ok("Cadastro realizado com sucesso!");
            return BadRequest("Não foi possivel cadastrar!");
        }

        [HttpGet]
        [Route("listaturmaalunos")]
        public async Task<IActionResult> GestAlunos()
        {
            var resposta = await _turmaAlunoDB.ListaTurmaAlunos();
            if (resposta != null) return Ok(resposta);
            return BadRequest("Não foi possivel listar as turmas");
        }

        [HttpGet]
        [Route("turmaalunoporid/{id}")]
        public async Task<IActionResult> GetAlunoPorId(int id)
        {
            var resposta = await _turmaAlunoDB.CarregaTurmaAlunoPorId(id);
            if (resposta != null) return Ok(resposta);
            return BadRequest("Cadastro não encontrado");
        }

        [HttpPut]
        [Route("atualizarlunoturma")]
        public async Task<IActionResult> Atualizar([FromBody] CadastroTurmaAlunoModel turmaAluno)
        {
            var resposta = await _turmaAlunoDB.AtualizarTurmaAluno(turmaAluno);
            if (resposta is true) return Ok("Cadastro atualizado com sucesso!");
            return BadRequest("Não foi possivel atualizar!");
        }
    }
}
