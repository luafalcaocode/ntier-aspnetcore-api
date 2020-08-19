using AutoMapper;
using luafalcao.api.Persistence.DataTransferObjects;
using luafalcao.api.Persistence.DataTransferObjects.Usuario;
using luafalcao.api.Persistence.Entities;
using luafalcao.api.Shared.Utils;

namespace luafalcao.api.Web.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ArtigoDto, Artigo>();
            CreateMap<Artigo, ArtigoDto>();

            #region Usuário
            CreateMap<UsuarioCadastroDto, Usuario>()
                .ForMember(usuarioEntity => usuarioEntity.UserName, option => option.MapFrom(usuarioDto => usuarioDto.Email));
            CreateMap<Usuario, UsuarioCadastroDto>()
                .ForMember(usuarioDto => usuarioDto.Email, option => option.MapFrom(usuarioEntity => usuarioEntity.Email));

            CreateMap<UsuarioAutenticacaoDto, Usuario>()
                .ForMember(usuarioEntity => usuarioEntity.UserName, option => option.MapFrom(usuarioDto => usuarioDto.Email));

            #endregion


            CreateMap(typeof(Message<>), typeof(Message<>));
        }
    }
}
