using Estudos.Domain.Interfaces.Repositories;
using Estudos.Domain.V1.Entidades.Usuario;
using System.Threading.Tasks;

namespace Estudos.Domain.V1.Interfaces.Repositories
{
    public interface IUsuarioRepository : IRepository<UsuarioBE>
    {
        Task SalvarUsuario(UsuarioBE usuario);
    }
}
