using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using alterdata.api.Facade.Contracts;
using alterdata.api.Persistence.DataTransferObjects.Recurso;
using alterdata.api.Shared.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;

namespace alterdata.api.Web.Controllers
{
    [ApiController]
    [Route("api/v1/recurso")]
    [Authorize]
    public class RecursoController : ControllerBase
    {
        private IRecursoFacade facade;

        public RecursoController(IRecursoFacade facade)
        {
            this.facade = facade;
        }

        [HttpGet]
        [Authorize(Roles = "Comum")]
        public async Task<IActionResult> GetRecursos()
        {
            var message = await this.facade.ObterTodos();
            return StatusCode(message.StatusCode, message);
        }

        private IActionResult GetResponse(dynamic message)
        {
           
            return Ok();
        }
    }
}