using alterdata.api.Persistence.DataTransferObjects;
using alterdata.api.Persistence.DataTransferObjects.Recurso;
using alterdata.api.Persistence.DataTransferObjects.Usuario;
using alterdata.api.Persistence.DataTransferObjects.Votacao;
using alterdata.api.Shared.Utils;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace alterdata.api.Facade.Contracts
{
    public interface IVotacaoFacade
    {
          Task<Message<IEnumerable<VotacaoDto>>> ObterTodos();
          Task<Message> Votar(VotacaoCadastroDto voto);
    }
}