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
    public class ConsumerCadastroTurmaAPI
    {
        public HttpStatusCode SalvarTurma(CadastroTurmaModel turmaModel)
        {

            var urlApi = "https://localhost:44305";
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                string json = JsonConvert.SerializeObject(turmaModel);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage webResponse = httpClient.PostAsync($"{urlApi}/api/CadastroTurma/cadastrarturma", content).Result;
                return webResponse.StatusCode;
            }
        }

        public CadastroTurmaModel CarregaTurmaPorId(int id)
        {
            CadastroTurmaModel turmasModel = null;
            var urlApi = "https://localhost:44305";
            var httpClient = new HttpClient();
            var lista = httpClient.GetAsync($"{urlApi}/api/CadastroTurma/turmaporid/{id}").Result;
            var jsonString = lista.Content.ReadAsStringAsync();
            jsonString.Wait();
            turmasModel = JsonConvert.DeserializeObject<CadastroTurmaModel>(jsonString.Result);
            return turmasModel;
        }

        public List<CadastroTurmaModel> CarregaTurmas()
        {
            List<CadastroTurmaModel> turmasModel = null;
            var urlApi = "https://localhost:44305";
            var httpClient = new HttpClient();
            var lista = httpClient.GetAsync($"{urlApi}/api/CadastroTurma/listaturmas").Result;
            var jsonString = lista.Content.ReadAsStringAsync();
            jsonString.Wait();
            turmasModel = JsonConvert.DeserializeObject<List<CadastroTurmaModel>>(jsonString.Result);
            return turmasModel;
        }

        public HttpStatusCode Atualizar(CadastroTurmaModel alunoModel)
        {

            var urlApi = "https://localhost:44305";
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                string json = JsonConvert.SerializeObject(alunoModel);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage webResponse = httpClient.PutAsync($"{urlApi}/api/CadastroTurma/atualizarturma", content).Result;
                return webResponse.StatusCode;
            }
        }

    }
}
