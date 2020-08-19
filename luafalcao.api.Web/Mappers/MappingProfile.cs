using luafalcao.api.Persistence.Entities;
using luafalcao.api.Persistence.DataTransferObjects;

using AutoMapper;

namespace luafalcao.api.Web.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Artigo, ArtigoDto>()
                .ForMember(a => a.DataPublicacao, options => options.MapFrom(model => model.DataPublicacao.ToShortDateString()));

            CreateMap<Comentario, ComentarioDto>()
                .ForMember(a => a.DataPublicacao, options => options.MapFrom(model => model.DataPublicacao.ToShortDateString()));

            CreateMap<UsuarioDto, Usuario>();
                
        }
    }
}
