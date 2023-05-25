using GestaoTurma.WEB.HttpClientConsumer;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace GestaoDeTurmas.WEB.Models
{
    public class CadastroTurmaAlunoModel
    {
        public int Aluno_Id { get; set; }
        public int Turma_Id { get; set; }
        public bool Ativo { get; set; } = true;
        [JsonIgnore]
        public List<CadastroAlunoModel> Alunos { get; set; }
        [JsonIgnore]
        public CadastroAlunoModel Aluno { get; set; }
        [JsonIgnore]
        public List<CadastroTurmaModel> Turmas { get; set; }
        [JsonIgnore]
        public CadastroTurmaModel Turma { get; set; }

        [JsonIgnore]
        public CadastroTurmaAlunoModel TurmaAlunoPorId { get; set; }

        public List<CadastroTurmaAlunoModel> TurmaAlunos { get; set; }
        public List<CadastroAlunoModel> CarregaAlunos()
        {
            ConsumerCadastroAlunoAPI consumerAPI = new ConsumerCadastroAlunoAPI();
            return consumerAPI.CarregaAlunos();
        }

        public List<CadastroTurmaModel> CarregaTurmas()
        {
            ConsumerCadastroTurmaAPI consumerAPI = new ConsumerCadastroTurmaAPI();
            return consumerAPI.CarregaTurmas();
        }

        public List<CadastroTurmaAlunoModel> CarregaTurmaAlunos()
        {
            ConsumerCadastroTurmaAlunoAPI consumerAPI = new ConsumerCadastroTurmaAlunoAPI();
            return consumerAPI.CarregaTurmaAlunos();
        }

        public bool SalvarturmaAluno(CadastroTurmaAlunoModel turmaAlunoModel)
        {
            ConsumerCadastroTurmaAlunoAPI consumerAPI = new ConsumerCadastroTurmaAlunoAPI();
            return Convert.ToBoolean(consumerAPI.SalvarTurmaAluno(turmaAlunoModel));
        }

        public bool AtualizarTurmaAluno(CadastroTurmaAlunoModel turmaAlunoModel)
        {
            ConsumerCadastroTurmaAlunoAPI consumerAPI = new ConsumerCadastroTurmaAlunoAPI();
            return Convert.ToBoolean(consumerAPI.Atualizar(turmaAlunoModel));
        }

        public CadastroTurmaAlunoModel CarregaTurmaAlunoPorId(int id)
        {
            ConsumerCadastroTurmaAlunoAPI consumerAPI = new ConsumerCadastroTurmaAlunoAPI();
            return consumerAPI.CarregaTurmaAlunoPorId(id);
        }

        public bool ValidarCampo(bool resultado, int turma, int aluno)
        {
            resultado = true;
            var turmaalunos = CarregaTurmaAlunos();
            foreach (var item in turmaalunos)
            {
                if (item.Aluno_Id.Equals(aluno) && item.Turma_Id.Equals(turma))
                {
                    resultado = false;
                }
            }
            return resultado;
        }
    }
}
