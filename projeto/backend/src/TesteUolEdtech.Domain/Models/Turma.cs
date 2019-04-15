using System;
using System.Collections.Generic;
using System.Text;
using TesteUolEdtech.Domain.Core.Models;
using TesteUolEdtech.Domain.Cursos.Validations;

namespace TesteUolEdtech.Domain.Models
{
    public class Turma : Entity<Turma>
    {
        public string Descricao { get; private set; }
        public int CursoId { get; private set; }
        public int PeriodoAcademicoId { get; private set; }

        public virtual Curso Curso { get; private set; }
        public virtual PeriodoAcademico PeriodoAcademico { get; private set; }
        public virtual ICollection<AlunoTurma> AlunosTurma { get; private set; }

        public Turma(string descricao, int cursoId, int periodoAcademicoId)
        {
            Descricao = descricao;
            CursoId = cursoId;
            PeriodoAcademicoId = periodoAcademicoId;

            AlunosTurma = new List<AlunoTurma>();
        }

        private Turma() { }

        public void AtribuirCurso(Curso curso)
        {
            Curso = curso;
        }

        public void AdicionarAlunoTurma(AlunoTurma alunoTurma)
        {
            if (AlunosTurma == null) AlunosTurma = new List<AlunoTurma>();

            if (!AlunosTurma.Contains(alunoTurma)) AlunosTurma.Add(alunoTurma);
        }

        public override bool EhValido()
        {
            ValidationResult = new TurmaValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
