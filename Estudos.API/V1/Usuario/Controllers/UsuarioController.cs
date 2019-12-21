using AutoMapper;
using Estudos.API.Controller;
using Estudos.API.Responses;
using Estudos.API.V1.Usuario.ViewModel;
using Estudos.Domain.V1.Entidades.Usuario;
using Estudos.Domain.V1.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Estudos.API.V1.Usuario.Controllers
{
    [Route("api/usuario")]
    [ApiController]
    public class UsuarioController : BaseController
    {

        private readonly IMapper mapper;
        private readonly IUsuarioService service;

        public UsuarioController(IMapper _mapper, IUsuarioService _service)
        {
            mapper = _mapper;
            service = _service;
        }

        [HttpGet]
        [SwaggerResponse(200, type: typeof(CadastroUsuarioViewModel))]
        [SwaggerResponse(404, type: typeof(HttpResponse))]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("{codigo}")]
        [SwaggerResponse(200, type: typeof(CadastroUsuarioViewModel))]
        [SwaggerResponse(404, type: typeof(HttpResponse))]
        public ActionResult<string> Get(int codigo)
        {
            return "value";
        }

        [HttpPost]
        public async Task<ActionResult<HttpResponse>> Post([FromBody] CadastroUsuarioViewModel _usuario)
        {
            var usuario = mapper.Map<UsuarioBE>(_usuario);
            await service.Incluir(usuario);

            if (!service.EhValido())
                return ApiResponse(code: HttpStatusCode.NotFound, service.ObterNotificacoes());

            return ApiResponse(code: HttpStatusCode.OK);
        }

        [HttpPut("{codigo}")]
        public async Task<ActionResult<HttpResponse>> Put(int codigo, [FromBody] CadastroUsuarioViewModel _usuario)
        {
            var usuario = mapper.Map<UsuarioBE>(_usuario);
            usuario.DefinirCodigo(codigo);
            await service.Atualizar(usuario);

            if (!service.EhValido())
                return ApiResponse(code: HttpStatusCode.NotFound, service.ObterNotificacoes());

            return ApiResponse(code: HttpStatusCode.NoContent);
        }

        [HttpDelete("{codigo}")]
        public async Task<ActionResult<HttpResponse>> Delete(int codigo)
        {
            await service.Remover(codigo);
            if (!service.EhValido())
                return ApiResponse(code: HttpStatusCode.NotFound, service.ObterNotificacoes());

            return ApiResponse(code: HttpStatusCode.NoContent);
        }
    }
}
