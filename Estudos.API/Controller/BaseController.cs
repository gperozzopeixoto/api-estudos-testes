using Estudos.API.Responses;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace Estudos.API.Controller
{
    [ApiController]
    [SwaggerResponse(200, "Operação concluída!", typeof(HttpResponse))]
    [SwaggerResponse(400, "Operação Inválida!", typeof(HttpErrorResponse))]
    [SwaggerResponse(401, "Sem autorização!", typeof(HttpResponse))]
    [SwaggerResponse(403, "Sem permissão!", typeof(HttpResponse))]
    [SwaggerResponse(500, "Erro interno!", typeof(HttpResponse))]
    [Produces("application/json")]
    [Consumes("application/json")]
    public class BaseController: ControllerBase
    {
        protected ActionResult<HttpResponse> ApiResponse(HttpStatusCode code, object data = null)
        {
            HttpResponse response = CriarResposta(code, data);

            switch (code)
            {
                case HttpStatusCode.NoContent:
                case HttpStatusCode.OK:
                    return Ok(response);
                case HttpStatusCode.NotFound:
                    return NotFound(response);
                case HttpStatusCode.BadRequest:
                    return BadRequest(response);
                default:
                    return NoContent();
            }
        }

        protected ActionResult<HttpResponse> CriarResposta(string rota, object routeValues, object value)
            => CreatedAtRoute(rota, routeValues, CriarResposta(HttpStatusCode.Created, value));

        private HttpResponse CriarResposta(HttpStatusCode httpCode, object data = null)
        {
            if (((int)httpCode) >= 200 && ((int)httpCode) < 300)
            {
                if (data != null)
                    return new HttpBodyResponse<object>(httpCode, data);

                return new HttpResponse(httpCode);
            }

            return new HttpErrorResponse(httpCode, data);
        }
    }
}
