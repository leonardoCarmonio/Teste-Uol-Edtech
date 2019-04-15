using System;
using System.Collections.Generic;
using System.Text;

namespace TesteUolEdtech.Domain.Interfaces.UoW
{
    public interface IUnitOfWork : IDisposable
    {
        bool Commit();
    }
}
