using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;
using TesteUolEdtech.Domain.Models;

namespace TesteUolEdtech.Domain.Validations
{
    public class PeriodoAcademicoDeveEstarAptoParaTrocaValidation : AbstractValidator<PeriodoAcademico>
    {
        private readonly PeriodoAcademico _periodoAcademicoComparacao;

        public PeriodoAcademicoDeveEstarAptoParaTrocaValidation(PeriodoAcademico periodoAcademicoComparacao)
        {
            _periodoAcademicoComparacao = periodoAcademicoComparacao;
            RuleFor(periodoAcademico => periodoAcademico.Descricao).Must(PeriodoAcademicoValido).WithMessage("Ambos os períodos acadêmicos devem ser pares ou ímpares.");
        }

        private bool PeriodoAcademicoValido(string descricao)
        {
            int ultimoNumeroPeriodoAcademico = int.Parse(descricao.Substring(descricao .Length - 1, 1));
            int ultimoNumeroPeriodoAcademicoComparacao = int.Parse(_periodoAcademicoComparacao.Descricao.Substring(_periodoAcademicoComparacao.Descricao .Length - 1, 1));

            return ((ultimoNumeroPeriodoAcademico % 2 == 0 && ultimoNumeroPeriodoAcademicoComparacao % 2 == 0) ||
                    (ultimoNumeroPeriodoAcademico % 2 > 0 && ultimoNumeroPeriodoAcademicoComparacao % 2 > 0));
        }
    }
}
