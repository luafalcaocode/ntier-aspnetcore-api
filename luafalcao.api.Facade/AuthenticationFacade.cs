using luafalcao.api.Facade.Contracts;
using luafalcao.api.Persistence.DataTransferObjects;
using luafalcao.api.Shared.Utils;
using luafalcao.api.Domain.Contracts.Adapters;
using luafalcao.api.Persistence.Entities;

using AutoMapper;

using System.Threading.Tasks;
using luafalcao.api.Persistence.DataTransferObjects.Usuario;

namespace luafalcao.api.Facade
{
    public class AuthenticationFacade : IAuthenticationFacade
    {
        private IMapper mapper;
        private IAuthenticationManager authenticationManager;

        public AuthenticationFacade(IMapper mapper, IAuthenticationManager authenticationManager)
        {
            this.mapper = mapper;
            this.authenticationManager = authenticationManager;
        }

        public async Task<Message<UsuarioCadastroDto>> RegisterUser(UsuarioCadastroDto usuarioDto)
        {
            var usuario = this.mapper.Map<Usuario>(usuarioDto);
            return this.mapper.Map<Message<UsuarioCadastroDto>>(await this.authenticationManager.RegisterUser(usuario));
        }

        public async Task<Message<string>> Login(UsuarioAutenticacaoDto usuarioDto)
        {
            var message = new Message<string>();
            var usuario = this.mapper.Map<Usuario>(usuarioDto);

            if (!await this.authenticationManager.ValidateUser(usuario))
            {
                message.Errors.Add("Authentication failed. Wrong username or password.");
                message.Success = false;

                return message;
            }

            message.Data = await this.authenticationManager.CreateToken();
            message.Success = true;

            return message;
        }
    }
}