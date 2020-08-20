using alterdata.api.Facade.Contracts;
using alterdata.api.Persistence.DataTransferObjects;
using alterdata.api.Shared.Utils;
using alterdata.api.Domain.Contracts.Adapters;
using alterdata.api.Persistence.Entities;

using AutoMapper;

using System.Threading.Tasks;
using alterdata.api.Persistence.DataTransferObjects.Usuario;

namespace alterdata.api.Facade
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