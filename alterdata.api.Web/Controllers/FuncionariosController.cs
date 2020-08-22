using alterdata.api.Facade.Contracts;
using alterdata.api.Persistence.DataTransferObjects.Funcionario;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace alterdata.api.Web.Controllers
{
    [ApiController]
    [Route("api/v1/funcionarios")]
    public class FuncionariosController : ControllerBase
    {
        private IFuncionarioFacade facade;
        public FuncionariosController(IFuncionarioFacade facade)
        {
            this.facade = facade;
        }

        [HttpGet]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> GetFuncionarios()
        {
            var message = await this.facade.ObterTodos();
            return StatusCode(message.StatusCode, message);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> GetFuncionarioPorId(int id)
        {
            var message = await this.facade.ObterPorId(id);
            return StatusCode(message.StatusCode, message);
        }

        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Post(FuncionarioDto funcionarioDto)
        {
            var message = await this.facade.Cadastrar(funcionarioDto);
            return StatusCode(message.StatusCode, message);
        }

        [HttpPut]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Update(FuncionarioDto funcionarioDto)
        {
            var message = await this.facade.Atualizar(funcionarioDto);
            return StatusCode(message.StatusCode, message);
        }

        [HttpDelete]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Delete(FuncionarioDto funcionarioDto)
        {
            var message = await this.facade.Remover(funcionarioDto);
            return StatusCode(message.StatusCode, message);
        }
    }
}