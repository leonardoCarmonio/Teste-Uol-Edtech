using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TesteUolEdtech.Domain.Models;
using TesteUolEdtech.Infra.Data.Extensions;

namespace TesteUolEdtech.Infra.Data.Mapping
{
    public class PeriodoAcademicoMapping : EntityTypeConfiguration<PeriodoAcademico>
    {
        public override void Map(EntityTypeBuilder<PeriodoAcademico> builder)
        {
            builder.Property(p => p.Descricao)
                .HasColumnName("Description")
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(p => p.Inicio)
                .HasColumnName("Start")
                .HasColumnType("datetime")
                .IsRequired();

            builder.Property(p => p.Fim)
                .HasColumnName("Finish")
                .HasColumnType("datetime")
                .IsRequired();

            builder.Ignore(p => p.ValidationResult);

            builder.Ignore(p => p.CascadeMode);

            builder.ToTable("AcademicPeriod");
        }
    }
}
