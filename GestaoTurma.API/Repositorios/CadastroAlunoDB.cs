using Dapper;
using GestaoDeTurmas.WEB.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoDeTurmas.API.Repositorios
{
    public class CadastroAlunoDB : ICadastroAlunoDB
    {
        private readonly string _conexaoBanco;

        public CadastroAlunoDB(ConfiguracaoCadastro config)
        {
            _conexaoBanco = config.ConexaoComBanco;
        }

        public async Task<bool> Cadastrar(CadastroAlunoModel aluno)
        {
            try
            {
                using var con = new SqlConnection(_conexaoBanco);
                var sql = @"INSERT INTO Aluno
                                           (Nome
                                           ,Usuario
                                           ,Senha
                                           ,Ativo)
                                     VALUES
                                           (@Nome
                                           ,@Usuario
                                           ,CAST(@Senha AS VARBINARY) 
                                           ,@Ativo)";
                return Convert.ToBoolean(con.Execute(sql, new { aluno.Nome, aluno.Usuario, aluno.Senha, aluno.Ativo }));
            }
            catch (System.Exception erro)
            {
                await Console.Out.WriteLineAsync(erro.Message);
                return false;
            }
        }
        public async Task<bool> Atualizar(CadastroAlunoModel aluno)
        {
            try
            {
                using (var con = new SqlConnection(_conexaoBanco))
                {
                    var sql = $@"UPDATE Aluno
                                   SET Nome = @Nome
                                      ,Usuario = @Usuario
                                       {(string.IsNullOrWhiteSpace(aluno.Senha) ? null : ",Senha = CAST(@Senha as varbinary)")}
                                      ,Ativo = @Ativo
                                       WHERE Id = @Id";
                    return Convert.ToBoolean((con.Execute(sql, new { aluno.Nome, aluno.Usuario, aluno.Senha, aluno.Ativo, aluno.Id})));
                }
            }
            catch (Exception erro)
            {
                await Console.Out.WriteLineAsync(erro.Message);
                return false;
            }
        }

        public async Task<List<CadastroAlunoModel>> ListaAlunos()
        {
            try
            {
                using (var con = new SqlConnection(_conexaoBanco))
                {
                    var query = @"SELECT Id
                                        ,Nome
                                        ,Usuario
                                        ,Ativo
                                    FROM Aluno
                                   WHERE Ativo = 1";
                    return con.Query<CadastroAlunoModel>(query).ToList();
                }
            }
            catch (Exception erro)
            {
                await Console.Out.WriteLineAsync(erro.Message);
                return new List<CadastroAlunoModel>();
            }
        }

        public async Task<CadastroAlunoModel> CarregaAlunoPorId(int id)
        {
            try
            {
                using (var con = new SqlConnection(_conexaoBanco))
                {
                    var query = @"SELECT Id
                                        ,Nome
                                        ,Usuario
                                        ,Ativo
                                    FROM Aluno
                                    WHERE Id = @Id";
                    return con.Query<CadastroAlunoModel>(query, new { id }).FirstOrDefault();
                }
            }
            catch (Exception erro)
            {
                await Console.Out.WriteLineAsync(erro.Message);
                return null;
            }
        }
    }
}
