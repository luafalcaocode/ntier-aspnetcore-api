using luafalcao.api.Facade.Contracts;
using luafalcao.api.Persistence.DataTransferObjects;
using luafalcao.api.Shared.Utils;
using luafalcao.api.Domain.Contracts.Adapters;
using luafalcao.api.Persistence.Entities;

using AutoMapper;

using System.Threading.Tasks;


namespace luafalcao.api.Facade
{
    public class AuthenticationFacade : IAuthenticationFacade
    {
        private IMapper mapper;
        private IUserManagerAdapter userManagerAdapater;

        public AuthenticationFacade(IMapper mapper, IUserManagerAdapter userManagerAdapater)
        {
            this.mapper = mapper;
            this.userManagerAdapater = userManagerAdapater;
        }

        public async Task<Message<UsuarioDto>> RegisterUser(UsuarioDto usuarioDto)
        {
            var usuario = this.mapper.Map<Usuario>(usuarioDto);
            return this.mapper.Map<Message<UsuarioDto>>(await this.userManagerAdapater.RegisterUser(usuario));
        }
    }
}