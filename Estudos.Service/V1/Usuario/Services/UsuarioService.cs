using System.Collections.Generic;
using System.Threading.Tasks;
using Estudos.Domain.Interfaces.UoW;
using Estudos.Domain.V1.Entidades.Usuario;
using Estudos.Domain.V1.Interfaces.Repositories;
using Estudos.Domain.V1.Interfaces.Services;
using Estudos.Domain.V1.Interfaces.Validador;
using Estudos.Domain.ValueObjects.Structs;
using Estudos.Service.Services;

namespace Estudos.Service.V1.Usuario.Services
{
    public class UsuarioService : BancoDadosService<UsuarioBE>, IUsuarioService
    {
        protected new readonly IUsuarioRepository _repository;

        public UsuarioService(IUsuarioRepository repository, IUsuarioValidador validador, IUnitOfWork unitOfWork) : base(repository, validador, unitOfWork)
        {
            _repository = repository;
        }

        public async Task SalvarUsuarioAsync(UsuarioBE usuario)
        {
            if(!(await _validador.Validar(usuario)))
            {
                AddNotificacoes(_validador.Erros);
                return;
            }

           await  _repository.SalvarUsuario(usuario);
        }
    }
}
