using alterdata.api.Facade.Contracts;
using alterdata.api.Persistence.DataTransferObjects.Recurso;
using alterdata.api.Persistence.DataTransferObjects.Votacao;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace alterdata.api.Web.Controllers
{
    [ApiController]
    [Route("api/v1/votacoes")]
    public class VotacoesController : ControllerBase
    {
        private IVotacaoFacade facade;

        public VotacoesController(IVotacaoFacade facade)
        {
            this.facade = facade;
        }

        [HttpGet]
        public async Task<IActionResult> GetVotos()
        {
            var message = await this.facade.ObterTodos();
            return StatusCode(message.StatusCode, message);
        }

        [HttpPost]
        public async Task<IActionResult> Post(VotacaoCadastroDto votacaoDto)
        {
            var message = await this.facade.Cadastrar(votacaoDto);
            return StatusCode(message.StatusCode, message);
        }
        
    }
}