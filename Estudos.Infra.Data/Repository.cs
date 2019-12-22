using Estudos.Domain;
using Estudos.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Estudos.Infra.Data
{
    public class Repository<TContext, TEntidade> : IRepository<TEntidade> where TEntidade : EntidadeBase where TContext : DbContext
    {
        protected readonly TContext _contexto;

        public Repository(TContext contexto)
        {
            _contexto = contexto;
        }

        public virtual async Task<TEntidade> BuscarPorId(long codigo)
            => await _contexto.Set<TEntidade>().FirstOrDefaultAsync(x => x.Codigo == codigo);

        public virtual IQueryable<TEntidade> Buscar()
            => _contexto.Set<TEntidade>();

        public virtual async Task Remover(long codigo)
        {
            TEntidade entidade = await BuscarPorId(codigo);
            _contexto.Entry(entidade).State = EntityState.Modified;
        }

        public bool VerificarExistencia(long codigo)
            => _contexto.Set<TEntidade>().Any(x => x.Codigo == codigo);

        public virtual async Task Incluir(TEntidade entidade)
        {
            await _contexto.AddAsync(entidade);
        }

        public virtual void Atualizar(TEntidade entidade)
        {
            _contexto.Entry(entidade).State = EntityState.Modified;
        }

        public async Task Salvar(IEnumerable<TEntidade> entidades, bool manterIdentificador = false)
        {
            List<TEntidade> entidadesParaUpdate = new List<TEntidade>();

            foreach (TEntidade item in entidades)
            {
                if (item.Codigo != 0 && VerificarExistencia(item.Codigo))
                {
                    _contexto.Entry(item).State = EntityState.Modified;
                    _contexto.Entry(item).Property(x => x.DataExclusao).IsModified = false;
                    _contexto.Entry(item).State = EntityState.Modified;
                    entidadesParaUpdate.Add(item);
                }
            }

            await _contexto.AddRangeAsync(entidades.Except(entidadesParaUpdate));
        }
    }
}
