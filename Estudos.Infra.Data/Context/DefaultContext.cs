using Estudos.Domain.V1.Entidades.Usuario;
using Microsoft.EntityFrameworkCore;

namespace Estudos.Infra.Data.Context
{
    public class DefaultContext : BaseContext
    {
        public DefaultContext(DbContextOptions<DefaultContext> options) : base(options)
        {

        }

        public DbSet<UsuarioBE> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DefaultContext).Assembly);
        }
    }
}
