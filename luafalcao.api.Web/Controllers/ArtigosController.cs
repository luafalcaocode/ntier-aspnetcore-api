using luafalcao.api.Facade.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace luafalcao.api.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtigosController : ControllerBase
    {
        private IBlogFacade _facade;

        public ArtigosController(IBlogFacade facade) => _facade = facade;

        [HttpGet]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> GetArtigos()
        {
            var artigos = await _facade.ObterTodosOsArtigos();
            if (artigos != null)
            {
                return Ok(artigos);
            }

            return NotFound();
        }
    }
}
