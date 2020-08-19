using luafalcao.api.Persistence.Entities;
using luafalcao.api.Persistence.DataTransferObjects;

using AutoMapper;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using luafalcao.api.Shared.Utils;

namespace luafalcao.api.Web.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UsuarioDto, Usuario>()
                .ForMember(usuarioEntity => usuarioEntity.UserName, option => option.MapFrom(usuarioDto => usuarioDto.Email));
            CreateMap<Usuario, UsuarioDto>()
                .ForMember(usuarioDto => usuarioDto.Email, option => option.MapFrom(usuarioEntity => usuarioEntity.Email));


            CreateMap(typeof(Message<>), typeof(Message<>));
        }
    }
}
