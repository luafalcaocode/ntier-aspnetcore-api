using alterdata.api.Facade.Contracts;
using alterdata.api.Persistence.DataTransferObjects;
using alterdata.api.Persistence.DataTransferObjects.Usuario;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace alterdata.api.Web.Controllers
{
    [ApiController]
    [Route("api/oauth")]
    public class AuthenticationController : ControllerBase
    {
        private IAuthenticationFacade authenticationFacade;

        public AuthenticationController(IAuthenticationFacade authenticationFacade)
        {
            this.authenticationFacade = authenticationFacade;
        }

        [HttpPost]
        [Route("usuario/registro")]
        public async Task<IActionResult> RegisterUser([FromBody] UsuarioCadastroDto usuarioDto)
        {
            var message = await this.authenticationFacade.RegisterUser(usuarioDto);
            return Ok(message);
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] UsuarioAutenticacaoDto usuarioDto)
        {
            var message = await this.authenticationFacade.Login(usuarioDto);

            if (!message.Success)
            {
                return Unauthorized(message);
            }

            return Ok(message);
        }
    }
}