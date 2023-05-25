using Dapper;
using GestaoDeTurmas.WEB.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoDeTurmas.API.Repositorios
{
    public class CadastroTurmaDB : ICadastroTurmaDB
    {
        private readonly string _conexaoBanco;

        public CadastroTurmaDB(ConfiguracaoCadastro config)
        {
            _conexaoBanco = config.ConexaoComBanco;
        }

        public async Task<bool> Cadastrar(CadastroTurmaModel turma)
        {
            try
            {
                using (var con = new SqlConnection(_conexaoBanco))
                {
                    var sql = @"INSERT INTO Turma
                                           (Curso_Id
                                           ,Turma
                                           ,Ano
                                           ,Ativo)
                                     VALUES
                                           (@Curso_Id
                                           ,@Turma
                                           ,@Ano
                                           ,@Ativo)";

                    return Convert.ToBoolean(con.Execute(sql, new { turma.Turma, turma.Ano, turma.Curso_Id, turma.Ativo }));
                }
            }
            catch (System.Exception erro)
            {
                await Console.Out.WriteLineAsync(erro.Message);
               return false;
            }
        }

        public async Task<bool> Atualizar(CadastroTurmaModel turma)
        {
            try
            {
                using (var con = new SqlConnection(_conexaoBanco))
                {
                    var sql = @"UPDATE Turma
                           SET Curso_Id = @Curso_Id
                              ,Turma = @Turma
                              ,Ano = @Ano
                              ,Ativo = @Ativo
                              WHERE Id = @Id";
                    return Convert.ToBoolean(con.Execute(sql, new { turma.Turma, turma.Ano, turma.Curso_Id, turma.Ativo, turma.Id }));
                }
            }
            catch (Exception erro)
            {
                await Console.Out.WriteLineAsync(erro.Message);
                return false;
            }
        }

        public async Task<List<CadastroTurmaModel>> ListaTurmas()
        {
            try
            {
                using (var con = new SqlConnection(_conexaoBanco))
                {
                    var query = @"SELECT Id
                                        ,Curso_Id
                                        ,Turma
                                        ,Ano
                                        ,Ativo
                                    FROM Turma
                                    WHERE Ativo = 1";
                    return con.Query<CadastroTurmaModel>(query).ToList();
                }
            }
            catch (Exception erro)
            {
                await Console.Out.WriteLineAsync(erro.Message);
                return new List<CadastroTurmaModel>();
            }
        }

        public async Task<CadastroTurmaModel> CarregaTurmaPorId(int id)
        {
            try
            {
                using (var con = new SqlConnection(_conexaoBanco))
                {
                    var query = @"SELECT Id
                                        ,Curso_Id
                                        ,Turma
                                        ,Ano
                                        ,Ativo
                                    FROM Turma
                                    Where Id = @Id";
                    return con.Query<CadastroTurmaModel>(query, new { id }).FirstOrDefault();
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
