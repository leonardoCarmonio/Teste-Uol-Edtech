using Dapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TesteUolEdtech.Domain.Interfaces.Repository;
using TesteUolEdtech.Domain.Models;
using TesteUolEdtech.Infra.Data.Context;

namespace TesteUolEdtech.Infra.Data.Repository
{
    public class TurmaRepository : Repository<Turma>, ITurmaRepository
    {
        public TurmaRepository(TesteUolEdtechContext context) : base(context) { }

        public Turma ObterTurmaParaMigracao(int idPeriodoAcademicoOrigem, int idPeriodoAcademicoDestino, int idTurma)
        {
            string sql = @"SELECT TOP 1 Class_New.Id, 
                                  Class_New.Description AS Descricao,
                                  Class_New.CourseId As CursoId,
                                  Class_New.AcademicPeriodId As PeriodoAcademicoId
                          FROM Class 
                          INNER JOIN Class AS Class_New
                          ON Class_New.CourseId = Class.CourseId
                          AND Class_New.AcademicPeriodId = @idPeriodoAcademicoDestino
                          WHERE Class.Id = @idTurma
                          AND Class.AcademicPeriodId = @idPeriodoAcademicoOrigem";

            return Db.Database.GetDbConnection().Query<Turma>(sql, param: new { idPeriodoAcademicoDestino, idTurma, idPeriodoAcademicoOrigem }).FirstOrDefault();
        }
    }
}
