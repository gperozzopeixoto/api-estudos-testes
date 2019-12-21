using Estudos.Domain.ValueObjects.Structs;
using System.Collections.Generic;

namespace Estudos.Domain.Interfaces.Service
{
    public interface IService
    {
        bool EhValido();
        List<Notificacao> ObterNotificacoes();
    }
}
