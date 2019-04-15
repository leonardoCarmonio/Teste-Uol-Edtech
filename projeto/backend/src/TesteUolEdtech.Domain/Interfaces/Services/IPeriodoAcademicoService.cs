using System;
using System.Collections.Generic;
using System.Text;
using TesteUolEdtech.Domain.Models;

namespace TesteUolEdtech.Domain.Interfaces.Services
{
    public interface IPeriodoAcademicoService : IBaseService
    {
        IEnumerable<PeriodoAcademico> ObterTodos();
    }
}
