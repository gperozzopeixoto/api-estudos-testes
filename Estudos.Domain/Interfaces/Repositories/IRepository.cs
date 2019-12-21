using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Estudos.Domain.Interfaces.Repositories
{
    public interface IRepository<TEntidade> where TEntidade : EntidadeBase
    {
        Task Incluir(TEntidade entidade);
        void Atualizar(TEntidade entidade);
        Task Salvar(IEnumerable<TEntidade> entidades, bool manterIdentificador = false);
        Task Remover(long codigo);
        Task<TEntidade> BuscarPorId(long codigo);
        IQueryable<TEntidade> Buscar();
        bool VerificarExistencia(long codigo);
    }
}
