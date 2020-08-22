using alterdata.api.Facade.Contracts;
using alterdata.api.Persistence.DataTransferObjects.Recurso;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace alterdata.api.Web.Controllers
{
    [ApiController]
    [Route("api/v1/recursos")]
    public class RecursosController : ControllerBase
    {
        private IRecursoFacade facade;

        public RecursosController(IRecursoFacade facade)
        {
            this.facade = facade;
        }

        [HttpGet]
        public async Task<IActionResult> GetRecursos()
        {
            var message = await this.facade.ObterTodos();
            return StatusCode(message.StatusCode, message);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRecursoPorId(int id)
        {
            var message = await this.facade.ObterPorId(id);
            return StatusCode(message.StatusCode, message);
        }

        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Post(RecursoDto recursoDto)
        {
            var message = await this.facade.Cadastrar(recursoDto);
            return StatusCode(message.StatusCode, message);
        }

        [HttpPut]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Update(RecursoDto recursoDto)
        {
            var message = await this.facade.Atualizar(recursoDto);
            return StatusCode(message.StatusCode, message);
        }

        [HttpDelete]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Delete(RecursoDto recursoDto)
        {
            var message = await this.facade.Remover(recursoDto);
            return StatusCode(message.StatusCode, message);
        }
    }
}