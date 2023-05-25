using GestaoDeTurmas.WEB.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Reflection.Metadata.Ecma335;

namespace GestaoDeTurmas.WEB.Controllers
{
    public class CadastroTurmaController : Controller
    {
        private readonly CadastroTurmaModel _model;

        public CadastroTurmaController()
        {
            _model = new CadastroTurmaModel();
        }
        public IActionResult Index()
        {

            _model.Turmas = _model.CarregaTurmas();
            return View(_model);
        }

        public IActionResult Cadastrar(CadastroTurmaModel turmaModel,  bool resultado)
        {
            var dataAtual = DateTime.Now.Year;
            var validarcampo = _model.ValidarCampo(resultado, turmaModel.Turma);
            if (turmaModel.Ano >= dataAtual && validarcampo)
            {
                _model.Salvarturma(turmaModel);
                TempData["MensagemSucesso"] = $"Turma cadastrada com sucesso";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["MensagemErro"] = $"Verifique se ja existe a turma cadastrada ou se o ano é inferior queatual";
                return RedirectToAction("Index");
            }
        }

        public IActionResult Editar(int id)
        {
            _model.TurmaPorId = _model.CarregaTurmaPorId(id);
            return View("Editar", _model);
        }

        public IActionResult Atualizar(CadastroTurmaModel turmaModel, bool resultado)
        {
            var dataAtual = DateTime.Now.Year;
            var validarcampo = _model.ValidarCampo(resultado, turmaModel.TurmaPorId.Turma);
            if (turmaModel.TurmaPorId.Ano >= dataAtual && validarcampo || turmaModel.TurmaPorId.Ativo is false)
            {
                _model.AtualizarTurma(turmaModel.TurmaPorId);
                TempData["MensagemSucesso"] = $"Turma atualizada com sucesso";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["MensagemErro"] = $"Verifique se ja existe a turma cadastrada ou se o ano é inferior queatual";
                return RedirectToAction("Index");
            }
        }
    }
}
