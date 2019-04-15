using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TesteUolEdtech.Domain.Models;
using TesteUolEdtech.Infra.Data.Extensions;
using TesteUolEdtech.Infra.Data.Mapping;

namespace TesteUolEdtech.Infra.Data.Context
{
    public class TesteUolEdtechContext : DbContext
    {
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Turma> Turmas { get; set; }
        public DbSet<PeriodoAcademico> PeriodosAcademico { get; set; }
        public DbSet<AlunoTurma> AlunosTurma { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<FluentValidation.Results.ValidationFailure>();
            modelBuilder.Ignore<FluentValidation.Results.ValidationResult>();

            modelBuilder.AddConfiguration(new CursoMapping());
            modelBuilder.AddConfiguration(new AlunoMapping());
            modelBuilder.AddConfiguration(new TurmaMapping());
            modelBuilder.AddConfiguration(new PeriodoAcademicoMapping());
            modelBuilder.AddConfiguration(new AlunoTurmaMapping());
            
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(System.IO.Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        }
    }
}
