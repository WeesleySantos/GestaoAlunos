using Dapper;
using GestaoDeTurmas.API;
using GestaoDeTurmas.WEB.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace GestaoTurma.API.Repositorios
{
    public class TurmaAlunoDB : ICadastroTurmaAlunoDB
    {
        private readonly string _conexaoBanco;

        public TurmaAlunoDB(ConfiguracaoCadastro config)
        {
            _conexaoBanco = config.ConexaoComBanco;
        }

        public async Task<bool> CadastrarTurmaAluno(CadastroTurmaAlunoModel turmaAluno)
        {
            try
            {
                using (var con = new SqlConnection(_conexaoBanco))
                {
                    var sql = @"INSERT INTO Aluno_Turma
                                           (Aluno_Id
                                           ,Turma_Id
                                           ,Ativo)
                                     VALUES
                                           (@Aluno_Id
                                           ,@Turma_Id
                                           ,@Ativo)";
                    return Convert.ToBoolean(con.Execute(sql, new
                    {
                        turmaAluno.Aluno_Id,
                        turmaAluno.Turma_Id,
                        turmaAluno.Ativo
                    }));
                }
            }
            catch (System.Exception erro)
            {
                await Console.Out.WriteLineAsync(erro.Message);
                return false;
            }
        }

        public async Task<bool> AtualizarTurmaAluno(CadastroTurmaAlunoModel turmaAluno)
        {
            try
            {
                using (var con = new SqlConnection(_conexaoBanco))
                {
                    var sql = @"UPDATE Aluno_Turma
                                   SET Aluno_Id = @Aluno_Id
                                      ,Turma_Id = @Turma_Id
                                      ,Ativo = @Ativo
                                       WHERE Aluno_Id = @Aluno_Id";
                    return Convert.ToBoolean(con.Execute(sql, new
                    {
                        turmaAluno.Aluno_Id,
                        turmaAluno.Turma_Id,
                        turmaAluno.Ativo

                    }));
                }
            }
            catch (System.Exception erro)
            {
                await Console.Out.WriteLineAsync(erro.Message);
                return false;
            }
        }
        public async Task<List<CadastroTurmaAlunoModel>> ListaTurmaAlunos()
        {
            try
            {
                using (var con = new SqlConnection(_conexaoBanco))
                {
                    var query = @"SELECT           AT.Aluno_Id
                                                  ,AT.Turma_Id
                                            	  ,A.Id
                                            	  ,A.Nome
                                            	  ,T.Id
                                            	  ,t.Turma
                                            FROM Aluno_Turma AT
                                            JOIN Aluno A ON A.Id = AT.Aluno_Id
                                            JOIN Turma T ON T.Id = AT.Turma_Id
                                    WHERE AT.Ativo = 1";
                    return con.Query<CadastroTurmaAlunoModel, CadastroAlunoModel, CadastroTurmaModel, CadastroTurmaAlunoModel>(query,

                    (turmaalunoModel,aluno,turma) =>
                    {
                        turmaalunoModel.Aluno = aluno;
                        turmaalunoModel.Turma = turma;
                        return turmaalunoModel;
                    }, splitOn: "Aluno_Id,Id,Id").ToList();
                }
            }
            catch (Exception erro)
            {
                await Console.Out.WriteLineAsync(erro.Message);
                return new List<CadastroTurmaAlunoModel>();
            }
        }

        public async Task<CadastroTurmaAlunoModel> CarregaTurmaAlunoPorId(int id)
        {
            using (var con = new SqlConnection(_conexaoBanco))
            {
                try
                {
                    var query = @"SELECT Aluno_Id
                                        ,Turma_Id
                                        ,Ativo
                                    FROM Aluno_Turma
                                    WHERE Aluno_Id = @Aluno_Id";
                    return con.Query<CadastroTurmaAlunoModel>(query, new {Aluno_Id = id }).FirstOrDefault();
                }
                catch (Exception erro)
                {
                    await Console.Out.WriteLineAsync(erro.Message);
                    return null;
                }
            }
        }
    }
}
