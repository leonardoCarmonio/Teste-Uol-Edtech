using System;
using System.Collections.Generic;
using System.Text;
using TesteUolEdtech.Domain.Models;

namespace TesteUolEdtech.Domain.Interfaces.Repository
{
    public interface ITurmaRepository : IRepository<Turma>
    {
        Turma ObterTurmaParaMigracao(int periodoAcademicoId, int periodoAcademicoMigracaoId, int turmaId);
    }
}
