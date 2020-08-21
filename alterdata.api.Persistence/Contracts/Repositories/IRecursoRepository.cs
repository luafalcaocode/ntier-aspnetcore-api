using System.Threading.Tasks;
using System.Collections.Generic;
using alterdata.api.Persistence.Entities;

namespace alterdata.api.Persistence.Contracts.Repositories
{
    public interface IRecursoRepository: IRepositoryBase<Recurso>
    {
        Task<IEnumerable<Recurso>> ObterTodos();
        Task<Recurso> ObterPorId(int id);
        void Cadastrar(Recurso recurso);
        void Atualizar(Recurso recurso);
        void Remover(Recurso recurso);        
    }
}