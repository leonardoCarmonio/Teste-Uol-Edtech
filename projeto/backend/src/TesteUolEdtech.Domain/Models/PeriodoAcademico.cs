using System;
using System.Collections.Generic;
using System.Text;
using TesteUolEdtech.Domain.Core.Models;
using TesteUolEdtech.Domain.Cursos.Validations;

namespace TesteUolEdtech.Domain.Models
{
    public class PeriodoAcademico : Entity<PeriodoAcademico>
    {
        public string Descricao { get; private set; }
        public DateTime Inicio { get; private set; }
        public DateTime Fim { get; private set; }
        public virtual ICollection<Turma> Turmas { get; private set; }

        public PeriodoAcademico(string descricao, DateTime inicio, DateTime fim)
        {
            Descricao = descricao;
            Inicio = inicio;
            Fim = fim;
            Turmas = new List<Turma>();
        }

        private PeriodoAcademico() { }

        public override bool EhValido()
        {
            ValidationResult = new PeriodoAcademicoValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
