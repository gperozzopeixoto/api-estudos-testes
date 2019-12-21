using Estudos.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Estudos.Infra.Data.Context
{
    public class BaseContext : DbContext
    {

        public BaseContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            DateTime dataAtual = DateTime.Now;
            foreach (Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<EntidadeBase> item in ChangeTracker.Entries<EntidadeBase>())
            {
                switch (item.State)
                {
                    case EntityState.Added:
                        item.Entity.DataInclusao = dataAtual;                        
                        break;
                    case EntityState.Modified:
                        if (item.Entity.DataExclusao == null)
                        {
                            Entry(item.Entity).Property(x => x.DataInclusao).IsModified = false;                            
                            item.Entity.DataAlteracao = dataAtual;                        
                        }
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
