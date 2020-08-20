using AutoMapper;
using alterdata.api.Persistence.DataTransferObjects;
using alterdata.api.Persistence.DataTransferObjects.Usuario;
using alterdata.api.Persistence.Entities;
using alterdata.api.Shared.Utils;

namespace alterdata.api.Web.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
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
