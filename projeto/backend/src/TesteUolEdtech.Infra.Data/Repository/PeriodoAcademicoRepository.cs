using System;
using System.Collections.Generic;
using System.Text;
using TesteUolEdtech.Domain.Interfaces.Repository;
using TesteUolEdtech.Domain.Models;
using TesteUolEdtech.Infra.Data.Context;

namespace TesteUolEdtech.Infra.Data.Repository
{
    public class PeriodoAcademicoRepository : Repository<PeriodoAcademico>, IPeriodoAcademicoRepository
    {
        public PeriodoAcademicoRepository(TesteUolEdtechContext context) : base(context) { }
    }
}
