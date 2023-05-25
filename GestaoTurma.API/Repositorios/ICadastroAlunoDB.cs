using GestaoDeTurmas.WEB.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoDeTurmas.API.Repositorios
{
    public interface ICadastroAlunoDB
    {
        Task<bool> Cadastrar(CadastroAlunoModel aluno);
        Task<bool> Atualizar(CadastroAlunoModel aluno);
        Task<List<CadastroAlunoModel>> ListaAlunos();
        Task<CadastroAlunoModel> CarregaAlunoPorId(int id);
    }
}
