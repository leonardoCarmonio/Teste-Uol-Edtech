using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using TesteUolEdtech.Services.API.AutoMapper;

namespace TesteUolEdtech.Services.API.Configurations
{
    public static class AutoMapperSetup
    {
        public static void AddAutoMapperSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddAutoMapper();
            services.AddSingleton(AutoMapperConfiguration.RegisterMappings());
        }
    }
}
