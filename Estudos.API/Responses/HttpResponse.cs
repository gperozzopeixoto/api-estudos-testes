using System.Net;

namespace Estudos.API.Responses
{
    public class HttpResponse
    {
        public HttpResponse(HttpStatusCode httpCode)
        {
            Success = true;
            HttpCode = (int)httpCode;
        }

        public bool Success { get; protected set; }
        public int HttpCode { get; protected set; }
    }
}
