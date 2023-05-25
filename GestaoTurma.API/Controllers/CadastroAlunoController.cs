using GestaoDeTurmas.API.Repositorios;
using GestaoDeTurmas.WEB.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GestaoDeTurmas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CadastroAlunoController : ControllerBase
    {
        private readonly ICadastroAlunoDB _cadastroDB;
        public CadastroAlunoController(ICadastroAlunoDB cadastroDB)
        {
            _cadastroDB = cadastroDB;
        }

        [HttpPost]
        [Route("cadastroaluno")]
        public async Task<IActionResult> CadastrarAluno(CadastroAlunoModel aluno)
        {
            var resposta = await _cadastroDB.Cadastrar(aluno);
            if (resposta is true) return Ok("Aluno cadastrado com sucesso!");
            return BadRequest("Não foi possivel cadastrar o aluno");
        }

        [HttpGet]
        [Route("listaalunos")]
        public async Task<IActionResult> GestAlunos()
        {
            var resposta = await _cadastroDB.ListaAlunos();
            if (resposta != null) return Ok(resposta);
            return BadRequest("Não foi possivel listar os alunos");
        }

        [HttpGet]
        [Route("alunoporid/{id}")]
        public async Task<IActionResult> GetAlunoPorId (int id)
        {
            var resposta = await _cadastroDB.CarregaAlunoPorId(id);
            if (resposta != null) return Ok(resposta);
            return BadRequest("Cadastro não encontrado");
        }

        [HttpPut]
        [Route("atualizaraluno")]

        public async Task<IActionResult> AtualizarAluno(CadastroAlunoModel aluno)
        {
            var resposta = await _cadastroDB.Atualizar(aluno);
            if (resposta is true) return Ok("Aluno atualizado com sucesso!");
            return BadRequest("Não foi possivel atualizar o aluno");
        }
    }
}
