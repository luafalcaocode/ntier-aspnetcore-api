using AutoMapper;
using alterdata.api.Persistence.DataTransferObjects;
using alterdata.api.Persistence.DataTransferObjects.Usuario;
using alterdata.api.Persistence.Entities;
using alterdata.api.Shared.Utils;
using alterdata.api.Persistence.DataTransferObjects.Recurso;
using alterdata.api.Persistence.DataTransferObjects.Funcionario;
using Microsoft.Extensions.Options;

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

            CreateMap<FuncionarioDto, Usuario>()
                .ForMember(usuario => usuario.UserName, option => option.MapFrom(funcionarioDto => funcionarioDto.Email));

            CreateMap<Usuario, FuncionarioDto>()
                .ForMember(funcionarioDto => funcionarioDto.FuncionarioId, option => option.MapFrom(usuario => usuario.Id));


            CreateMap<Usuario, Funcionario>()
                .ForMember(funcionario => funcionario.FuncionarioId, option => option.MapFrom(usuario => usuario.Id));
            
            CreateMap<Funcionario, Usuario>()
                .ForMember(usuario => usuario.Id, option => option.MapFrom(funcionario => funcionario.FuncionarioId)); ;
                
            #endregion

            #region Recurso
            CreateMap<RecursoDto, Recurso>();
            CreateMap<Recurso, RecursoDto>();
            #endregion

            CreateMap(typeof(Message<>), typeof(Message<>));
        }
    }
}
