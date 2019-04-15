using System;
using System.Collections.Generic;
using System.Text;
using TesteUolEdtech.Domain.Interfaces.UoW;
using TesteUolEdtech.Infra.Data.Context;

namespace TesteUolEdtech.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TesteUolEdtechContext _context;

        public UnitOfWork(TesteUolEdtechContext context)
        {
            _context = context;
        }

        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
