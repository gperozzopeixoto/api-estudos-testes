using Estudos.Domain.Interfaces.Service;
using Estudos.Domain.V1.Entidades.Usuario;
using System.Threading.Tasks;

namespace Estudos.Domain.V1.Interfaces.Services
{
    public interface IUsuarioService : IBancoDadosService<UsuarioBE>
    {
        Task SalvarUsuarioAsync(UsuarioBE usuario);
    }
}
