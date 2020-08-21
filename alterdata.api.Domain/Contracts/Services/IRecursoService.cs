using alterdata.api.Persistence.Entities;

using System.Collections.Generic;
using System.Threading.Tasks;


namespace alterdata.api.Domain.Contracts.Services
{
    public interface IRecursoService
    {
        Task<IEnumerable<Recurso>> ObterTodos();
        Task<Recurso> ObterPorId(int id);
        Task Cadastrar(Recurso recurso);
        Task Atualizar(Recurso recurso);
        Task Remover(Recurso recurso);
    }
}