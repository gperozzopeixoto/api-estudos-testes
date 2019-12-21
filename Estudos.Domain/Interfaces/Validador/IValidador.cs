using Estudos.Domain.ValueObjects.Structs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Estudos.Domain.Interfaces.Validador
{
    public interface IValidador<TEntidade> where TEntidade : EntidadeBase
    {
        Task<bool> Validar(TEntidade entidade);
        Task<bool> Validar(IEnumerable<TEntidade> entidades);
        List<Notificacao> Erros { get; }
    }
}
