using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Estudos.Domain.Interfaces.Service
{
    public interface IBancoDadosService<TEntidade> : IService where TEntidade : EntidadeBase
    {
        Task Incluir(TEntidade entidade);
        Task Atualizar(TEntidade entidade);
        Task Salvar(IEnumerable<TEntidade> entidades);
        Task Remover(long codigo);
        Task<TEntidade> BuscarPorId(long codigo);
        IQueryable<TEntidade> Buscar();
        bool VerificarExistencia(long codigo);
    }
}
