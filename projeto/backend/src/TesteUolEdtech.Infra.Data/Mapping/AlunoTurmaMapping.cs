using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TesteUolEdtech.Domain.Models;
using TesteUolEdtech.Infra.Data.Extensions;

namespace TesteUolEdtech.Infra.Data.Mapping
{
    public class AlunoTurmaMapping : EntityTypeConfiguration<AlunoTurma>
    {
        public override void Map(EntityTypeBuilder<AlunoTurma> builder)
        {
            builder.Property(at => at.Status)
                   .HasColumnName("status")
                   .HasColumnType("char(1)");

            builder.Property(at => at.TurmaIdOrigem)
                   .HasColumnName("ClassId_Origin")
                   .HasColumnType("int");

            builder.Property(at => at.AlunoId)
                   .HasColumnName("StudentId")
                   .HasColumnType("int");

            builder.Property(at => at.TurmaId)
                   .HasColumnName("ClassId")
                   .HasColumnType("int");

            builder.HasOne(at => at.Turma)
                    .WithMany(t => t.AlunosTurma)
                    .HasForeignKey(at => at.TurmaId);

            builder.HasOne(at => at.Aluno)
                    .WithMany(a => a.AlunosTurma)
                    .HasForeignKey(at => at.AlunoId);

            builder.Ignore(e => e.CascadeMode);

            builder.ToTable("Student_Class");
        }
    }
}
