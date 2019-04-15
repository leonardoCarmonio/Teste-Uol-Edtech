using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TesteUolEdtech.Domain.Models;
using TesteUolEdtech.Infra.Data.Extensions;

namespace TesteUolEdtech.Infra.Data.Mapping
{
    public class CursoMapping : EntityTypeConfiguration<Curso>
    {
        public override void Map(EntityTypeBuilder<Curso> builder)
        {
            builder.Property(c => c.Descricao)
              .HasColumnName("Description")
              .HasColumnType("varchar(50)")
              .IsRequired();

            builder.Ignore(c => c.ValidationResult);

            builder.Ignore(c => c.CascadeMode);

            builder.ToTable("Course");
        }
    }
}
