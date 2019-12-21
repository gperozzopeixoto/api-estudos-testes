using AutoMapper;
using Estudos.API.V1.Usuario.Mapper;
using Estudos.Infra.Data.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace Estudos.API
{
    public static class APISettings
    {
        #region Swagger

        public static void AdicionarServicoSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Estudos API", Version = "v1" });
            });
        }

        public static void UsarServicoSwagger(this IApplicationBuilder app)
        {
            //Ativa o Swagger
            app.UseSwagger();

            // Ativa o Swagger UI
            app.UseSwaggerUI(opt =>
            {
                opt.SwaggerEndpoint("/swagger/v1/swagger.json", "Estudos API v1");
            });
        }

        #endregion

        #region AutoMapper

        public static void AdicionarConfiguracaoAutoMapeamento(this IServiceCollection servicos)
        {
            MapperConfiguration mapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MapperProfile());
            });
            servicos.AddSingleton<IMapper>(sp => mapper.CreateMapper());
        }

        #endregion

        #region DataBase
        public static void AdicionarBancoDados(this IServiceCollection servicos, string connection)
        {
            servicos.AddDbContext<DefaultContext>(optionsAction => optionsAction.UseSqlServer(connection));
        }
        #endregion
    }
}
