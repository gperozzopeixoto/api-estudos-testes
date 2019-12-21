using System.Threading.Tasks;
using Estudos.Domain.Interfaces.UoW;
using Estudos.Infra.Data.Context;

namespace Estudos.Infra.Data.UoW
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private readonly DefaultContext _context;

        public UnitOfWork(DefaultContext context)
        {
            _context = context;
        }

        public async Task<bool> Commit()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
