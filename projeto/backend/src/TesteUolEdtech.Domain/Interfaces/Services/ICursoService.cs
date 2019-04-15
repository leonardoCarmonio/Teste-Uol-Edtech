using System;
using System.Collections.Generic;
using System.Text;
using TesteUolEdtech.Domain.Models;

namespace TesteUolEdtech.Domain.Interfaces.Services
{
    public interface ICursoService : IBaseService
    {
        IEnumerable<Curso> ObterCursosCompleto();
        IEnumerable<Curso> ObterCursosParaMigracaoDeTurmaPorPeriodoAcademico(int idPeriodoAcademicoOrigem, int idPeriodoAcademicoDestino);
        void MigrarAlunosDeTurma(PeriodoAcademico periodoAcademico, PeriodoAcademico periodoAcademicoMigracao, IEnumerable<Turma> turmasMigracao);
    }
}
