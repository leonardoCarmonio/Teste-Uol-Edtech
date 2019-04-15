using Dapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using TesteUolEdtech.Domain.Interfaces.Repository;
using TesteUolEdtech.Domain.Models;
using TesteUolEdtech.Infra.Data.Context;

namespace TesteUolEdtech.Infra.Data.Repository
{
    public class CursoRepository : Repository<Curso>, ICursoRepository
    {
        public CursoRepository(TesteUolEdtechContext context) : base(context) { }

        public IEnumerable<Curso> ObterCursosParaMigracaoDeTurmaPorPeriodoAcademico(int idPeriodoAcademicoOrigem, int idPeriodoAcademicoDestino)
        {
            var turmaDictionary = new Dictionary<int, Turma>();
            var cursoDictionary = new Dictionary<int, Curso>();

            string sqlTurma = @"SELECT Class.Description AS Descricao, 
                                    Class.Id,
                                    Class.CourseId AS CursoId,
                                    Class.AcademicPeriodId AS PeriodoAcademicoId, 
                                    Course.Id, 
                                    Course.Description AS Descricao,
                                    Student_Class.Id,
                                    Student_Class.ClassId AS TurmaId, 
                                    Student_Class.StudentId AS AlunoId, 
                                    Student.Id,
                                    Student.Name AS Nome " +
                      "FROM Class " +
                      "INNER JOIN Class AS New_Class " +
                      "ON New_Class.AcademicPeriodId = @idPeriodoAcademicoDestino " +
                      "AND New_Class.CourseId = Class.CourseId " +
                      "INNER JOIN Student_Class ON Class.Id = Student_Class.ClassId " +
                      "INNER JOIN Student ON Student.Id = Student_Class.StudentId " +
                      "INNER JOIN COURSE ON Course.Id = Class.CourseId " +
                      "WHERE Class.AcademicPeriodId = @idPeriodoAcademicoOrigem " +
                      "AND Student_Class.status IS NULL " +
                      "AND Student_Class.ClassId_Origin IS NULL ";

            var turmas = Db.Database.GetDbConnection().Query<Turma, Curso, AlunoTurma, Aluno, Turma>(sqlTurma,
                (turma, curso, alunoTurma, aluno) =>
                {
                    if (!turmaDictionary.TryGetValue(turma.Id, out Turma turmaRetorno))
                    {
                        turmaRetorno = turma;
                        turmaDictionary.Add(turmaRetorno.Id, turmaRetorno);
                    }

                    if (curso != null)
                        turmaRetorno.AtribuirCurso(curso);

                    if (alunoTurma != null)
                        turmaRetorno.AdicionarAlunoTurma(alunoTurma);

                    if (alunoTurma != null && aluno != null)
                        alunoTurma.AtribuirAluno(aluno);

                    return turmaRetorno;
                }, param: new { idPeriodoAcademicoDestino, idPeriodoAcademicoOrigem }).AsQueryable();
            
            
            foreach (var turma in turmaDictionary)
            {
                if (!cursoDictionary.TryGetValue(turma.Value.CursoId, out Curso cursoTurma))
                {
                    cursoTurma = turma.Value.Curso;
                    cursoDictionary.Add(cursoTurma.Id, cursoTurma);
                }
                
                cursoTurma.AdicionarTurma(turma.Value);
            }
            
            return cursoDictionary.Values;
        }

        public IEnumerable<Curso> ObterCursosCompleto()
        {
            var cursoDictionary = new Dictionary<int, Curso>();
            var turmaDictionary = new Dictionary<int, Turma>();

            string sqlTurma = @"SELECT Class.Description AS Descricao, 
                                    Class.Id,
                                    Class.CourseId AS CursoId,
                                    Class.AcademicPeriodId AS PeriodoAcademicoId, 
                                    Course.Id, 
                                    Course.Description AS Descricao,
                                    Student_Class.Id,
                                    Student_Class.ClassId AS TurmaId, 
                                    Student_Class.StudentId AS AlunoId, 
                                    Student.Id,
                                    Student.Name AS Nome " +
                      "FROM Class " +
                      "INNER JOIN COURSE ON Course.Id = Class.CourseId " +
                      "LEFT JOIN Student_Class ON Class.Id = Student_Class.ClassId " +
                      "LEFT JOIN Student ON Student.Id = Student_Class.StudentId ";

            var turmas = Db.Database.GetDbConnection().Query<Turma, Curso, AlunoTurma, Aluno, Turma>(sqlTurma,
                (turma, curso, alunoTurma, aluno) =>
                {
                    if (!turmaDictionary.TryGetValue(turma.Id, out Turma turmaRetorno))
                    {
                        turmaRetorno = turma;
                        turmaDictionary.Add(turmaRetorno.Id, turmaRetorno);
                    }

                    if (curso != null)
                        turmaRetorno.AtribuirCurso(curso);

                    if (alunoTurma != null)
                        turmaRetorno.AdicionarAlunoTurma(alunoTurma);

                    if (alunoTurma != null && aluno != null)
                        alunoTurma.AtribuirAluno(aluno);

                    return turmaRetorno;
                }).AsQueryable();

            foreach (var turma in turmaDictionary)
            {
                if (!cursoDictionary.TryGetValue(turma.Value.CursoId, out Curso cursoTurma))
                {
                    cursoTurma = turma.Value.Curso;
                    cursoDictionary.Add(turma.Value.CursoId, cursoTurma);
                }

                cursoTurma.AdicionarTurma(turma.Value);
            }

            return cursoDictionary.Values;
        }
    }
}
