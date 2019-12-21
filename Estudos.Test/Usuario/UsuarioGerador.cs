using Bogus;
using Estudos.Domain.V1.Entidades.Usuario;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Estudos.Test.Usuario
{
    [CollectionDefinition(nameof(UsuarioCollection))]
    public class UsuarioCollection : ICollectionFixture<UsuarioGerador>
    { }

    public class UsuarioGerador : IDisposable
    {
        public UsuarioBE GerarUsuarioValido()
        {
            return new Faker<UsuarioBE>("pt_BR").RuleFor(x => x.Nome, option => option.Person.FullName)
                                         .RuleFor(x => x.Email, option => option.Internet.Email())
                                         .RuleFor(x => x.Ativo, option => option.Random.Bool())
                                         .RuleFor(x => x.Senha, option => option.Internet.Password());
        }

        public void Dispose()
        {
            
        }
    }
}
