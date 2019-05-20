using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pro.Exam.Builder.Datas;
using Pro.Exam.Builder.Datas.Repositories;
using Pro.Exam.Builder.Domain;
using Pro.Exam.Builder.Domain.Interfaces;
using Pro.Exam.Builder.Domain.Interfaces.Documents;
using Pro.Exam.Builder.Domain.Interfaces.Services;
using Pro.Exam.Builder.Domain.Services;
using System;

namespace Pro.Exam.Builder.Ioc
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration Configuration)
        {
            return services
                .AddSingleton(Configuration)
                .AddScoped<IConnection, Connection>()
                .RegisterServices()
                .RegisterRepositories();
        }

        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<ICombosService, CombosService>();
            services.AddScoped<IExamsService, ExamsService>();
            services.AddScoped<IUsersService, UsersService>();
            services.AddScoped<IDocumentDocX, DocumentDocX>();

            return services;
        }

        public static IServiceCollection RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<ICombosRepository, CombosRepository>();
            services.AddScoped<IExamsRepository, ExamsRepository>();
            services.AddScoped<IUsersRepository, UsersRepository>();

            return services;
        }
    }
}
