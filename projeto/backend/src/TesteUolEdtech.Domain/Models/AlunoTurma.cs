using System;
using System.Collections.Generic;
using System.Text;
using TesteUolEdtech.Domain.Core.Models;

namespace TesteUolEdtech.Domain.Models
{
    public class AlunoTurma : Entity<AlunoTurma>
    {
        public int AlunoId { get; private set; }
        public Aluno Aluno { get; private set; }

        public int TurmaId { get; private set; }
        public Turma Turma { get; private set; }

        public char? Status { get; private set; }

        public int? TurmaIdOrigem { get; private set; }

        public AlunoTurma() { }

        public void AtribuirAluno(Aluno aluno)
        {
            Aluno = aluno;
        }

        public void AtribuirTurma(Turma turma)
        {
            Turma = turma;
        }

        public void AlterarParaMigrado()
        {
            Status = 'M';
        }

        public override bool EhValido()
        {
            return true;
        }

        public static class AlunoTurmaFactory
        {
            public static AlunoTurma NovoAlunoTurmaAtribuindoSomenteAluno(Aluno aluno)
            {
                return new AlunoTurma() { Aluno = aluno, AlunoId = aluno.Id };
            }

            public static AlunoTurma NovoAlunoTurmaCompleto(int alunoId, int turmaId, int turmaIdOrigem)
            {
                return new AlunoTurma() { AlunoId = alunoId, TurmaId = turmaId, TurmaIdOrigem = turmaIdOrigem };
            }
        }
    }
}