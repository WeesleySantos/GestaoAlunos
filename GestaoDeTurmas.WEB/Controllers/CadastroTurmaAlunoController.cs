using GestaoDeTurmas.WEB.Models;
using Microsoft.AspNetCore.Mvc;

namespace GestaoDeTurmas.WEB.Controllers
{
    public class CadastroTurmaAlunoController : Controller
    {
        private readonly CadastroTurmaAlunoModel _model;

        public CadastroTurmaAlunoController()
        {
            _model = new CadastroTurmaAlunoModel();
        }
        public IActionResult Index()
        {
            _model.Alunos = _model.CarregaAlunos();
            _model.Turmas = _model.CarregaTurmas();
            _model.TurmaAlunos = _model.CarregaTurmaAlunos();
            return View(_model);
        }

        public IActionResult Cadastrar(CadastroTurmaAlunoModel turmaAluno, bool resultado)
        {
            var validarcampo = _model.ValidarCampo(resultado, turmaAluno.Turma_Id, turmaAluno.Aluno_Id);
            if (validarcampo)
            {
                _model.SalvarturmaAluno(turmaAluno);
                TempData["MensagemSucesso"] = $"Turma Relacionada com sucesso";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["MensagemErro"] = $"Esse Aluno ja está Relacionado com essa turma";
                return RedirectToAction("Index");
            }
        }
    }
}
