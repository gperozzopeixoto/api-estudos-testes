using Estudos.Domain;
using Estudos.Domain.Interfaces.Validador;
using Estudos.Domain.ValueObjects.Structs;
using FluentValidation;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Estudos.Service.Validador
{
    public class BaseValidator<TEntidade> : AbstractValidator<TEntidade>, IValidador<TEntidade> where TEntidade : EntidadeBase
    {
        public BaseValidator()
        {
            this.Erros = new List<Notificacao>();
        }

        public List<Notificacao> Erros { get; protected set; }

        public virtual async Task<bool> Validar(TEntidade entidade)
        {
            var resultado = await base.ValidateAsync(entidade);
            Erros.AddRange(resultado.Errors.Select(x => new Notificacao(x.ErrorMessage, x.ErrorCode)));
            return resultado.IsValid;
        }

        public virtual async Task<bool> Validar(IEnumerable<TEntidade> entidades)
        {
            foreach (var item in entidades)
            {
                var resultado = await base.ValidateAsync(item);
                Erros.AddRange(resultado.Errors.Select(x => new Notificacao(x.ErrorMessage, x.ErrorCode)));
            }
            return !Erros.Any();
        }
    }
}
