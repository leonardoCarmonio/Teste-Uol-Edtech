using FluentValidation.Results;
using System;

namespace TesteUolEdtech.Domain.Interfaces.Services
{
    public interface IBaseService : IDisposable
    {
        bool ProcessamentoRealizadoComSucesso();
    }
}
