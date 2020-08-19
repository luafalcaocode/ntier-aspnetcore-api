using luafalcao.api.Facade.Contracts;
using luafalcao.api.Persistence.DataTransferObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace luafalcao.api.Web.Controllers
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
        [Authorize]
        [Route("usuario/registro")]
        public async Task<IActionResult> RegisterUser(UsuarioDto usuarioDto)
        {
            var message = await this.authenticationFacade.RegisterUser(usuarioDto);
            return Ok(message);
        }

    }
}