using Estudos.Domain.V1.Entidades.Usuario;
using Estudos.Domain.V1.Interfaces.Repositories;
using Estudos.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Estudos.Infra.Data.V1.Usuario.Repositories
{
    public class UsuarioRepository : Repository<DefaultContext, UsuarioBE>, IUsuarioRepository
    {
        public UsuarioRepository(DefaultContext options) : base(options)
        {
        }

        public async Task<UsuarioBE> ObterUsuarioPorEmailESenha(string email, string senha)
        {
            return await _contexto.Usuarios.FirstOrDefaultAsync(x => x.Email == email && x.Senha == senha);
        }

        public async Task SalvarUsuario(UsuarioBE usuario)
        {
            await _contexto.Usuarios.AddAsync(usuario);
        }
    }
}