using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using TesteUolEdtech.Domain.Interfaces.Repository;
using TesteUolEdtech.Domain.Interfaces.Services;
using TesteUolEdtech.Domain.Interfaces.UoW;
using TesteUolEdtech.Domain.Services;
using TesteUolEdtech.Infra.Data.Context;
using TesteUolEdtech.Infra.Data.Repository;
using TesteUolEdtech.Infra.Data.UoW;

namespace TesteUolEdtech.Infra.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<ICursoService, CursoService>();
            services.AddScoped<IPeriodoAcademicoService, PeriodoAcademicoService>();

            services.AddScoped<ICursoRepository, CursoRepository>();
            services.AddScoped<IPeriodoAcademicoRepository, PeriodoAcademicoRepository>();
            services.AddScoped<IAlunoTurmaRepository, AlunoTurmaRepository>();
            services.AddScoped<ITurmaRepository, TurmaRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<TesteUolEdtechContext>();
        }
    }
}
