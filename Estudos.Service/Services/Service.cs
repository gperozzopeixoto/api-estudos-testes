using Estudos.Domain.Interfaces.Service;
using Estudos.Domain.ValueObjects.Structs;
using System.Collections.Generic;
using System.Linq;

namespace Estudos.Service.Services
{
    public class Service : IService
    {
        public Service()
        {
            Notificacoes = new List<Notificacao>();
        }

        List<Notificacao> Notificacoes { get; }

        public bool EhValido()
        {
            return !Notificacoes.Any();
        }

        public List<Notificacao> ObterNotificacoes()
        {
            return Notificacoes;
        }

        protected void AddNotificacao(Notificacao validacao)
        {
            Notificacoes.Add(validacao);
        }

        protected void AddNotificacoes(IEnumerable<Notificacao> validacoes)
        {
            Notificacoes.AddRange(validacoes);
        }
    }
}
