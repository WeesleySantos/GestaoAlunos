using GestaoDeTurmas.WEB.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace GestaoTurma.WEB.HttpClientConsumer
{
    public class ConsumerCadastroTurmaAlunoAPI
    {
        public HttpStatusCode SalvarTurmaAluno(CadastroTurmaAlunoModel turmaModel)
        {

            var urlApi = "https://localhost:44305";
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                string json = JsonConvert.SerializeObject(turmaModel);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage webResponse = httpClient.PostAsync($"{urlApi}/api/CadastroTurmaAluno/cadastraralunoturma", content).Result;
                return webResponse.StatusCode;
            }
        }

        public CadastroTurmaAlunoModel CarregaTurmaAlunoPorId(int id)
        {
            CadastroTurmaAlunoModel turmasModel = null;
            var urlApi = "https://localhost:44305";
            var httpClient = new HttpClient();
            var lista = httpClient.GetAsync($"{urlApi}/api/CadastroTurmaAluno/turmaalunoporid/{id}").Result;
            var jsonString = lista.Content.ReadAsStringAsync();
            jsonString.Wait();
            turmasModel = JsonConvert.DeserializeObject<CadastroTurmaAlunoModel>(jsonString.Result);
            return turmasModel;
        }

        public List<CadastroTurmaAlunoModel> CarregaTurmaAlunos()
        {
            List<CadastroTurmaAlunoModel> turmasModel = null;
            var urlApi = "https://localhost:44305";
            var httpClient = new HttpClient();
            var lista = httpClient.GetAsync($"{urlApi}/api/CadastroTurmaAluno/listaturmaalunos").Result;
            var jsonString = lista.Content.ReadAsStringAsync();
            jsonString.Wait();
            turmasModel = JsonConvert.DeserializeObject<List<CadastroTurmaAlunoModel>>(jsonString.Result);
            return turmasModel;
        }

        public HttpStatusCode Atualizar(CadastroTurmaAlunoModel alunoModel)
        {

            var urlApi = "https://localhost:44305";
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                string json = JsonConvert.SerializeObject(alunoModel);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage webResponse = httpClient.PutAsync($"{urlApi}/api/CadastroTurmaAluno/atualizarlunoturma", content).Result;
                return webResponse.StatusCode;
            }
        }

    }
}
