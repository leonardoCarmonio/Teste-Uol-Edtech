using System.Collections.Generic;
using TesteUolEdtech.Domain.Models;

namespace TesteUolEdtech.Domain.Interfaces.Repository
{
    public interface ICursoRepository : IRepository<Curso>
    {
        IEnumerable<Curso> ObterCursosCompleto();
        IEnumerable<Curso> ObterCursosParaMigracaoDeTurmaPorPeriodoAcademico(int idPeriodoAcademicoOrigem, int idPeriodoAcademicoDestino);
    }
}
