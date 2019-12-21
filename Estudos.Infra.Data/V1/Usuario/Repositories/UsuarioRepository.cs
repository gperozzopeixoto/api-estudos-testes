using Estudos.Domain.V1.Entidades.Usuario;
using Estudos.Domain.V1.Interfaces.Repositories;
using Estudos.Infra.Data.Context;
using System.Threading.Tasks;

namespace Estudos.Infra.Data.V1.Usuario.Repositories
{
    public class UsuarioRepository : Repository<DefaultContext, UsuarioBE>, IUsuarioRepository
    {
        public UsuarioRepository(DefaultContext context) : base(context)
        {

        }

        public async Task SalvarUsuario(UsuarioBE usuario)
        {
            await _contexto.Usuarios.AddAsync(usuario);
        }
    }
}