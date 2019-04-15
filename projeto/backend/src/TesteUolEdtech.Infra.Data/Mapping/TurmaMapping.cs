using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TesteUolEdtech.Domain.Models;
using TesteUolEdtech.Infra.Data.Extensions;

namespace TesteUolEdtech.Infra.Data.Mapping
{
    public class TurmaMapping : EntityTypeConfiguration<Turma>
    {
        public override void Map(EntityTypeBuilder<Turma> builder)
        {
            builder.Property(t => t.Descricao)
               .HasColumnName("Description")
               .HasColumnType("varchar(100)")
               .IsRequired();

            builder.Property(t => t.CursoId)
               .HasColumnName("CourseId")
               .HasColumnType("int")
               .IsRequired();

            builder.Property(t => t.PeriodoAcademicoId)
               .HasColumnName("AcademicPeriodId")
               .HasColumnType("int")
               .IsRequired();

            builder.HasOne(t => t.Curso)
                .WithMany(c => c.Turmas)
                .HasForeignKey(t => t.CursoId);

            builder.HasOne(t => t.PeriodoAcademico)
                .WithMany(p => p.Turmas)
                .HasForeignKey(t => t.PeriodoAcademicoId);

            builder.Ignore(e => e.ValidationResult);

            builder.Ignore(e => e.CascadeMode);

            builder.ToTable("Class");
        }
    }
}
