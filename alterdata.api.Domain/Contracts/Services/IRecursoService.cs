using alterdata.api.Persistence.Entities;

using System.Collections.Generic;
using System.Threading.Tasks;


namespace alterdata.api.Domain.Contracts.Services
{
    public interface IRecursoService
    {
        Task<IEnumerable<Recurso>> ObterTodos();
        Task<Recurso> ObterPorId(int id);
        void Cadastrar(Recurso recurso);
        void Atualizar(Recurso recurso);
        void Remover(Recurso recurso);
    }
}