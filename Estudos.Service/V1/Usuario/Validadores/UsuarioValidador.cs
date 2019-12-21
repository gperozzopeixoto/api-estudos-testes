using Estudos.Domain.V1.Entidades.Usuario;
using Estudos.Domain.V1.Interfaces.Validador;
using Estudos.Service.Validador;
using FluentValidation;
using System.Threading.Tasks;

namespace Estudos.Service.V1.Usuario.Validadores
{
    public class UsuarioValidador : BaseValidator<UsuarioBE>, IUsuarioValidador
    {
        private const short TAMANHO_MAXIMO_NOME = 100;

        public UsuarioValidador()
        {
            RuleFor(x => x.Nome).NotNull().NotEmpty().MaximumLength(TAMANHO_MAXIMO_NOME);
        }

        public override async Task<bool> Validar(UsuarioBE entidade)
        {
            return await base.Validar(entidade);
        }
    }
}
