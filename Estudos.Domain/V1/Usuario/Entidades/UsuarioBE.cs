using System;

namespace Estudos.Domain.V1.Entidades.Usuario
{
    public class UsuarioBE : EntidadeBase
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public bool Ativo { get; set; }

        public void InativarUsuario()
        {
            Ativo = false;
            DataExclusao = DateTime.Now;
        }

        public void DefinirCodigo(int codigo)
        {
            Codigo = codigo;
        }

        public bool UsuarioEstaAtivo() => Ativo;
    }
}
