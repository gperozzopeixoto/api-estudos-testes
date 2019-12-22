using Estudos.Domain.Interfaces.UoW;
using Estudos.Domain.V1.Interfaces.Validador;
using Estudos.Infra.Data.UoW;
using Estudos.Infra.Data.V1.Usuario.Repositories;
using Estudos.Service.V1.Usuario.Services;
using Estudos.Service.V1.Usuario.Validadores;
using Microsoft.Extensions.DependencyInjection;

namespace Estudos.Infra.CrossCutting.IoC
{
    public static class IocSettings
    {
        public static void AddIoCApplication(this IServiceCollection services)
        {
            services.Scan(scan => scan
                    .FromAssemblyOf<UsuarioRepository>()
                        .AddClasses(classes => classes.Where(type => type.FullName.EndsWith("Repository")))
                        .AsMatchingInterface()
                            .AsSelf()
                            .WithScopedLifetime()

           .FromAssemblyOf<UsuarioService>()
            .AddClasses(classes => classes.Where(type => type.FullName.EndsWith("Service")))
            .AsMatchingInterface()
                .AsSelf()
                .WithScopedLifetime()
            .FromAssemblyOf<UsuarioValidador>()
            .AddClasses(classes => classes.Where(type => type.FullName.EndsWith("Validador")))
                .AsSelf()
                .WithScopedLifetime());

            services.AddScoped<IUsuarioValidador, UsuarioValidador>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
