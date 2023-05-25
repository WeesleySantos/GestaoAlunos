using GestaoDeTurmas.WEB.Models;
using Microsoft.AspNetCore.Mvc;

namespace GestaoDeTurmas.WEB.Controllers
{
    public class CadastroAlunoController : Controller
    {
        private readonly CadastroAlunoModel _model;
        public CadastroAlunoController()
        {
            _model = new CadastroAlunoModel();
        }
        public IActionResult Index()
        {
            _model.Alunos = _model.CarregaAlunos();
            return View(_model);
        }

        public IActionResult Cadastrar(CadastroAlunoModel alunoModel)
        {
            try
            {
                if (!ModelState.IsValid || !alunoModel.SenhaCorreta())
                {
                    TempData["MensagemErro"] = $"Sua senha não é igual a Confirmação de senha. Tente novamente";
                    return RedirectToAction("Index");
                }
                alunoModel.LimparConfirmacaoDeSenha();
                alunoModel.SetSenhaHash();
                _model.SalvarAluno(alunoModel);
                TempData["MensagemSucesso"] = "Usuário cadastrado com sucesso!";
                return RedirectToAction("Index");
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Ops,Não conseguimos cadastrar o Aluno, tente novamente, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }
        public IActionResult Editar(int id)
        {
            _model.AlunoPorId = _model.CarregaAlunoPorId(id);
            return View("Editar", _model);
        }

        public IActionResult Atualizar(CadastroAlunoModel alunoModel)
        {
            _model.AtualizarAluno(alunoModel.AlunoPorId);
            return RedirectToAction("Index");
        }
    }
}
