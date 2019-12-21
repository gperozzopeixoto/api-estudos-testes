using AutoMapper;
using Estudos.API.V1.Usuario.ViewModel;
using Estudos.Domain.V1.Entidades.Usuario;

namespace Estudos.API.V1.Usuario.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<CadastroUsuarioViewModel, UsuarioBE>().ReverseMap();
        }
    }
}
