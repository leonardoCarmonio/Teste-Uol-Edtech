using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TesteUolEdtech.Domain.Models;
using TesteUolEdtech.Infra.Data.Extensions;

namespace TesteUolEdtech.Infra.Data.Mapping
{
    public class AlunoMapping : EntityTypeConfiguration<Aluno>
    {
        public override void Map(EntityTypeBuilder<Aluno> builder)
        {
            builder.Property(e => e.Nome)
                .HasColumnName("Name")
                .HasColumnType("varchar(500)")
                .IsRequired();

            builder.Ignore(e => e.ValidationResult);

            builder.Ignore(e => e.CascadeMode);

            builder.ToTable("Student");
        }
    }
}
