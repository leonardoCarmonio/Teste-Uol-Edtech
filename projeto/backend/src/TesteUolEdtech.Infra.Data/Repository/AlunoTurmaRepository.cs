using System;
using System.Collections.Generic;
using System.Text;
using TesteUolEdtech.Domain.Interfaces.Repository;
using TesteUolEdtech.Domain.Models;
using TesteUolEdtech.Infra.Data.Context;

namespace TesteUolEdtech.Infra.Data.Repository
{
    public class AlunoTurmaRepository : Repository<AlunoTurma>, IAlunoTurmaRepository
    {
        public AlunoTurmaRepository(TesteUolEdtechContext context) : base(context) { }
    }
}
