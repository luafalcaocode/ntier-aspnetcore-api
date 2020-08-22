using alterdata.api.Persistence.DataTransferObjects.Recurso;
using alterdata.api.Shared.Utils;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace alterdata.api.Facade.Contracts
{
    public interface IRecursoFacade
    {
        Task<Message<IEnumerable<RecursoDto>>> ObterTodos();
        Task<Message<RecursoDto>> ObterPorId(int id);
        Task<Message> Cadastrar(RecursoCadastroDto recurso);
        Task<Message> Atualizar(RecursoDto recurso);
        Task<Message> Remover(RecursoDto recurso);
    }
}