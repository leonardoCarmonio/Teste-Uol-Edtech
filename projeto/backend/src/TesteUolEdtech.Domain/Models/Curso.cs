using System;
using System.Collections.Generic;
using System.Text;
using TesteUolEdtech.Domain.Core.Models;
using TesteUolEdtech.Domain.Cursos.Validations;

namespace TesteUolEdtech.Domain.Models
{
    public class Curso : Entity<Curso>
    {
        public string Descricao { get; private set; }
        public virtual ICollection<Turma> Turmas { get; private set; }

        public Curso(string descricao)
        {
            Descricao = descricao;
            Turmas = new List<Turma>();
        }

        private Curso() { }

        public void AdicionarTurma(Turma turma)
        {
            if (Turmas == null) Turmas = new List<Turma>();

            if (!Turmas.Contains(turma)) Turmas.Add(turma);
        }

        public override bool EhValido()
        {
            ValidationResult = new CursoValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
