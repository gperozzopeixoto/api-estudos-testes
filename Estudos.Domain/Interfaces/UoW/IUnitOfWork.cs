using System;
using System.Threading.Tasks;

namespace Estudos.Domain.Interfaces.UoW
{
    public interface IUnitOfWork : IDisposable
    {
        Task<bool> Commit();
    }
}
