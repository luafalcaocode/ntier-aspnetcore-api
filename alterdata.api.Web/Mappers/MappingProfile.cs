using AutoMapper;
using alterdata.api.Persistence.DataTransferObjects;
using alterdata.api.Persistence.DataTransferObjects.Usuario;
using alterdata.api.Persistence.Entities;
using alterdata.api.Shared.Utils;
using alterdata.api.Persistence.DataTransferObjects.Recurso;
using alterdata.api.Persistence.DataTransferObjects.Funcionario;
using Microsoft.Extensions.Options;
using alterdata.api.Persistence.DataTransferObjects.Votacao;

namespace alterdata.api.Web.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            MapFuncionario();
            MapUsuario();
            MapRecurso();
            MapVotacao();
            
            CreateMap(typeof(Message<>), typeof(Message<>));
        }

        void MapFuncionario()
        {
            CreateMap<FuncionarioDto, Funcionario>();
            CreateMap<Funcionario, FuncionarioDto>();

            CreateMap<FuncionarioCadastroDto, Funcionario>();
            CreateMap<Funcionario, FuncionarioCadastroDto>();

            CreateMap<FuncionarioCadastroDto, Usuario>()
                .ForMember(usuario => usuario.UserName, option => option.MapFrom(funcionarioDto => funcionarioDto.Email));

            CreateMap<Usuario, FuncionarioDto>()
                .ForMember(funcionarioDto => funcionarioDto.FuncionarioId, option => option.MapFrom(usuario => usuario.Id));


            CreateMap<Usuario, Funcionario>()
                .ForMember(funcionario => funcionario.FuncionarioId, option => option.MapFrom(usuario => usuario.Id));

            CreateMap<Funcionario, Usuario>()
                .ForMember(usuario => usuario.Id, option => option.MapFrom(funcionario => funcionario.FuncionarioId)); ;
        }

        void MapUsuario()
        {
            CreateMap<UsuarioCadastroDto, Usuario>()
               .ForMember(usuarioEntity => usuarioEntity.UserName, option => option.MapFrom(usuarioDto => usuarioDto.Email));
            CreateMap<Usuario, UsuarioCadastroDto>()
                .ForMember(usuarioDto => usuarioDto.Email, option => option.MapFrom(usuarioEntity => usuarioEntity.Email));

            CreateMap<UsuarioAutenticacaoDto, Usuario>()
                .ForMember(usuarioEntity => usuarioEntity.UserName, option => option.MapFrom(usuarioDto => usuarioDto.Email));
        }

        void MapRecurso()
        {
            CreateMap<RecursoCadastroDto, Recurso>();
            CreateMap<RecursoDto, Recurso>();
            CreateMap<Recurso, RecursoDto>();
        }

        void MapVotacao()
        {
            CreateMap<VotacaoCadastroDto, Votacao>();

            CreateMap<VotacaoDto, Votacao>();
            CreateMap<Votacao, VotacaoDto>();
        }
    }
}
