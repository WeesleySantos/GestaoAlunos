using GestaoDeTurmas.WEB.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoTurma.API.Repositorios
{
    public interface ICadastroTurmaAlunoDB
    {
        Task<bool> CadastrarTurmaAluno(CadastroTurmaAlunoModel turmaAluno);
        Task<bool> AtualizarTurmaAluno(CadastroTurmaAlunoModel turmaAluno);
        Task<List<CadastroTurmaAlunoModel>> ListaTurmaAlunos();
        Task<CadastroTurmaAlunoModel> CarregaTurmaAlunoPorId(int id);
      
    }
}
