namespace Estudos.Domain.ValueObjects.Structs
{
    public struct Notificacao
    {
        public Notificacao(string mensagem, string codigo = null)
        {
            this.Mensagem = mensagem;
            this.Codigo = codigo;
        }

        public string Mensagem { get; }
        public string Codigo { get; }
    }
}
