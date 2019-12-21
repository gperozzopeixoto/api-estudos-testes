using System.Net;

namespace Estudos.API.Responses
{
    public class HttpErrorResponse : HttpResponse
    {
        public HttpErrorResponse(HttpStatusCode httpCode, object erros) : base(httpCode)
        {
            Success = false;
            Erros = erros;
        }

        public object Erros { get; private set; }
    }
}
