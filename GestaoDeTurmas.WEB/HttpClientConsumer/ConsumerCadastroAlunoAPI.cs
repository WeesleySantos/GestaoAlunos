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
    public class ConsumerCadastroAlunoAPI
    {
        public HttpStatusCode SalvarAluno(CadastroAlunoModel alunoModel)
        {

            var urlApi = "https://localhost:44305";
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                string json = JsonConvert.SerializeObject(alunoModel);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage webResponse = httpClient.PostAsync($"{urlApi}/api/CadastroAluno/cadastroaluno", content).Result;
                return webResponse.StatusCode;
            }
        }

        public CadastroAlunoModel CarregaAlunoPorId(int id)
        {
            CadastroAlunoModel alunosModel = null;
            var urlApi = "https://localhost:44305";
            var httpClient = new HttpClient();
            var lista = httpClient.GetAsync($"{urlApi}/api/CadastroAluno/alunoporid/{id}").Result;
            var jsonString = lista.Content.ReadAsStringAsync();
            jsonString.Wait();
            alunosModel = JsonConvert.DeserializeObject<CadastroAlunoModel>(jsonString.Result);
            return alunosModel;
        }

        public List<CadastroAlunoModel> CarregaAlunos()
        {
            List<CadastroAlunoModel> alunosModel = null;
            var urlApi = "https://localhost:44305";
            var httpClient = new HttpClient();
            var lista = httpClient.GetAsync($"{urlApi}/api/CadastroAluno/listaAlunos").Result;
            var jsonString = lista.Content.ReadAsStringAsync();
            jsonString.Wait();
            alunosModel = JsonConvert.DeserializeObject<List<CadastroAlunoModel>>(jsonString.Result);
            return alunosModel;
        }

        public HttpStatusCode Atualizar(CadastroAlunoModel alunoModel)
        {

            var urlApi = "https://localhost:44305";
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                string json = JsonConvert.SerializeObject(alunoModel);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage webResponse = httpClient.PutAsync($"{urlApi}/api/CadastroAluno/atualizaraluno", content).Result;
                return webResponse.StatusCode;
            }
        }

    }
}
