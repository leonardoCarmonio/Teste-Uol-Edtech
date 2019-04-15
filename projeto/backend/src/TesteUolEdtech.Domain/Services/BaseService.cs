using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace TesteUolEdtech.Domain.Services
{
    public abstract class BaseService
    {
        protected IList<ValidationResult> ValidacoesProcesso = new List<ValidationResult>();

        protected void AdicionarResultadoProcessamento(ValidationResult validationResult)
        {
            ValidacoesProcesso.Add(validationResult);
        }

        public bool ProcessamentoRealizadoComSucesso()
        {
            var valido = true;

            foreach (var validacaoProcesso in ValidacoesProcesso)
            {
                if (!validacaoProcesso.IsValid)
                    valido = false;
            }

            return valido;
        }
    }
}
