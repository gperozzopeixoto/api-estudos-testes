using AutoMapper;
using Estudos.API.Controller;
using Estudos.API.Responses;
using Estudos.API.V1.Usuario.ViewModel;
using Estudos.Domain.V1.Entidades.Usuario;
using Estudos.Domain.V1.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;
using System.Threading.Tasks;

namespace Estudos.API.V1.Usuario.Controllers
{
    [Route("api/usuario")]
    [ApiController]
    public class UsuarioController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IUsuarioService _service;

        public UsuarioController(IMapper mapper, IUsuarioService service)
        {
            _mapper = mapper;
            _service = service;
        }

        [HttpGet]
        [SwaggerResponse(200, type: typeof(HttpBodyResponse<UsuarioViewModel>))]
        [SwaggerResponse(404, type: typeof(HttpResponse))]
        public async Task<ActionResult<HttpResponse>> Get([FromBody] LoginViewModel dadosLogin)
        {
            UsuarioBE dadosUsuario = await _service.ObterUsuarioPorEmailESenha(dadosLogin.Email, dadosLogin.Senha);

            if (!_service.EhValido())
            {
                return ApiResponse(code: HttpStatusCode.NotFound, _service.ObterNotificacoes());
            }

            UsuarioViewModel retorno = _mapper.Map<UsuarioViewModel>(dadosUsuario);
            return ApiResponse(code: HttpStatusCode.OK, data: retorno);
        }

        [HttpPost]
        public async Task<ActionResult<HttpResponse>> Post([FromBody] CadastroUsuarioViewModel _usuario)
        {
            UsuarioBE usuario = _mapper.Map<UsuarioBE>(_usuario);
            await _service.Incluir(usuario);

            if (!_service.EhValido())
            {
                return ApiResponse(code: HttpStatusCode.NotFound, _service.ObterNotificacoes());
            }

            return ApiResponse(code: HttpStatusCode.OK);
        }

        [HttpPut("{codigo}")]
        public async Task<ActionResult<HttpResponse>> Put(int codigo, [FromBody] CadastroUsuarioViewModel _usuario)
        {
            UsuarioBE usuario = _mapper.Map<UsuarioBE>(_usuario);
            usuario.DefinirCodigo(codigo);
            await _service.Atualizar(usuario);

            if (!_service.EhValido())
            {
                return ApiResponse(code: HttpStatusCode.NotFound, _service.ObterNotificacoes());
            }

            return ApiResponse(code: HttpStatusCode.NoContent);
        }

        [HttpDelete("{codigo}")]
        public async Task<ActionResult<HttpResponse>> Delete(int codigo)
        {
            await _service.Remover(codigo);
            if (!_service.EhValido())
            {
                return ApiResponse(code: HttpStatusCode.NotFound, _service.ObterNotificacoes());
            }

            return ApiResponse(code: HttpStatusCode.NoContent);
        }
    }
}
