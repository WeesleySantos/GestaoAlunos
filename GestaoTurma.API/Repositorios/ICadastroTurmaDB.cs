using GestaoDeTurmas.WEB.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoDeTurmas.API.Repositorios
{
    public interface ICadastroTurmaDB
    {
        Task<bool> Cadastrar(CadastroTurmaModel turma);
        Task<bool> Atualizar(CadastroTurmaModel turma);
        Task<List<CadastroTurmaModel>> ListaTurmas();
        Task<CadastroTurmaModel> CarregaTurmaPorId(int id);
    }
}
