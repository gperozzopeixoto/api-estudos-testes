using Estudos.Infra.CrossCutting.IoC;
using Estudos.Infra.Data.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Estudos.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AdicionarServicoSwagger();
            services.AdicionarConfiguracaoAutoMapeamento();
            services.AddIoCApplication();
            services.AdicionarBancoDados(Configuration.GetConnectionString("Default"));
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, DefaultContext context)
        {
          
            app.UsarServicoSwagger();
            app.UseHttpsRedirection();
            app.UseMvc();
            context.Database.Migrate();
        }
    }
}

