using Xunit;

namespace Estudos.Test.Usuario
{
    [Collection(nameof(UsuarioCollection))]
    public class UsuarioTest
    {
        private readonly UsuarioGerador _usuarioGerador;

        public UsuarioTest(UsuarioGerador usuarioGerador)
        {
            _usuarioGerador = usuarioGerador;
        }

        [Fact(DisplayName = "Novo Usuário Válido")]
        [Trait("Categoria", "Usuário")]
        public void Usuario_SalvaUsuario_DeveEstarValido()
        {
            var cliente = _usuarioGerador.GerarUsuarioValido();
            Assert.NotNull(cliente);
        }
    }
}
