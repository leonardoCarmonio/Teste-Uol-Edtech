using System;
using System.Collections.Generic;
using System.Text;
using TesteUolEdtech.Domain.Core.Models;
using TesteUolEdtech.Domain.Cursos.Validations;

namespace TesteUolEdtech.Domain.Models
{
    public class Aluno : Entity<Aluno>
    {
        public string Nome { get; private set; }
        public virtual ICollection<AlunoTurma> AlunosTurma { get; private set; }

        public Aluno(string nome)
        {
            Nome = nome;
            AlunosTurma = new List<AlunoTurma>();
        }

        private Aluno() { }

        public override bool EhValido()
        {
            ValidationResult = new AlunoValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public static class AlunoFactory
        {
            public static Aluno NovoAlunoCompleto(int id, string nome)
            {
                return new Aluno() { Id = id, Nome = nome };
            }
        }
    }
}
