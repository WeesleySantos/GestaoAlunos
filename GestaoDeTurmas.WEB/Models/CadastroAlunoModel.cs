using ControleContatos.Helper;
using GestaoTurma.WEB.HttpClientConsumer;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace GestaoDeTurmas.WEB.Models
{
    public class CadastroAlunoModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("nome")]
        public string Nome { get; set; }
        [JsonPropertyName("usuario")]
        public string Usuario { get; set; }
        [JsonPropertyName("senha")]
        public string Senha { get; set; }
        [JsonIgnore]
        public string ConfirmarSenha { get; set; }
        [JsonPropertyName("ativo")]
        public bool Ativo { get; set; } = true;

        [JsonIgnore]
        public List<CadastroAlunoModel> Alunos { get; set; }

        [JsonIgnore]
        public CadastroAlunoModel AlunoPorId { get; set; }

        public List<CadastroAlunoModel> CarregaAlunos()
        {
            ConsumerCadastroAlunoAPI consumerAPI = new ConsumerCadastroAlunoAPI();
            return consumerAPI.CarregaAlunos();
        }

        public CadastroAlunoModel CarregaAlunoPorId(int id)
        {
            ConsumerCadastroAlunoAPI consumerAPI = new ConsumerCadastroAlunoAPI();
            return consumerAPI.CarregaAlunoPorId(id);
        }

        public bool SalvarAluno(CadastroAlunoModel alunoModel)
        {
            ConsumerCadastroAlunoAPI consumerAPI = new ConsumerCadastroAlunoAPI();
            return Convert.ToBoolean(consumerAPI.SalvarAluno(alunoModel));
        }

        public bool AtualizarAluno(CadastroAlunoModel alunoModel)
        {
            ConsumerCadastroAlunoAPI consumerAPI = new ConsumerCadastroAlunoAPI();
            return Convert.ToBoolean(consumerAPI.Atualizar(alunoModel));
        }
        public bool SenhaCorreta()
        {
            return Senha == ConfirmarSenha;
        }
        public bool SenhaValida(string senha)
        {
            return Senha == senha.GerarHash();
        }

        public void SetSenhaHash()
        {
            Senha = Senha.GerarHash();
        }
        public void LimparConfirmacaoDeSenha()
        {
            ConfirmarSenha = "";
        }
    }
}
