using AutoMapper;
using alterdata.api.Persistence.DataTransferObjects;
using alterdata.api.Persistence.DataTransferObjects.Usuario;
using alterdata.api.Persistence.Entities;
using alterdata.api.Shared.Utils;
using alterdata.api.Persistence.DataTransferObjects.Recurso;
using alterdata.api.Persistence.DataTransferObjects.Funcionario;

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

            #region Funcionario
            CreateMap<FuncionarioDto, Funcionario>();
            CreateMap<Funcionario, FuncionarioDto>();
            #endregion

            #region Recurso
            CreateMap<RecursoDto, Recurso>();
            CreateMap<Recurso, RecursoDto>();
            #endregion

            CreateMap(typeof(Message<>), typeof(Message<>));
        }
    }
}
