using GestaoTurma.WEB.HttpClientConsumer;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace GestaoDeTurmas.WEB.Models
{
    public class CadastroTurmaModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("curso_id")]
        public int Curso_Id { get; set; }
        [JsonProperty("turma")]
        public string Turma { get; set; }
        [JsonProperty("ano")]
        public int Ano { get; set; }
        [JsonProperty("ativo")]
        public bool Ativo { get; set; } = true;
        [JsonIgnore]
        public CadastroTurmaModel TurmaPorId { get; set; }
        [JsonIgnore]
        public List<CadastroTurmaModel> Turmas { get; set; } = new List<CadastroTurmaModel>();
        public bool Salvarturma(CadastroTurmaModel turmaModel)
        {
            ConsumerCadastroTurmaAPI consumerAPI = new ConsumerCadastroTurmaAPI();
            return Convert.ToBoolean(consumerAPI.SalvarTurma(turmaModel));
        }

        public List<CadastroTurmaModel> CarregaTurmas()
        {
            ConsumerCadastroTurmaAPI consumerAPI = new ConsumerCadastroTurmaAPI();
            return consumerAPI.CarregaTurmas();
        }

        public CadastroTurmaModel CarregaTurmaPorId(int id)
        {
            ConsumerCadastroTurmaAPI consumerAPI = new ConsumerCadastroTurmaAPI();
            return consumerAPI.CarregaTurmaPorId(id);
        }

        public bool AtualizarTurma(CadastroTurmaModel alunoModel)
        {
            ConsumerCadastroTurmaAPI consumerAPI = new ConsumerCadastroTurmaAPI();
            return Convert.ToBoolean(consumerAPI.Atualizar(alunoModel));
        }

        public bool ValidarCampo(bool resultado, string turma)
        {
            resultado = true;
            var turmas = CarregaTurmas();
            foreach (var item in turmas)
            {
                if (item.Turma.Equals(turma))
                {
                    resultado = false;
                }
            }
            return resultado;
        }
    }
}
