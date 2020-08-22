using alterdata.api.Persistence.Contracts.Repositories;
using alterdata.api.Persistence.Entities;
using alterdata.api.Persistence.Contexts;

using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace alterdata.api.Persistence.Repositories
{
    public class RecursoRepository : RepositoryBase<Recurso>, IRecursoRepository
    {
        public RecursoRepository(RepositoryContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Recurso>> ObterTodos()
        {
            return await FindAll()
            .OrderByDescending(recurso => recurso.NumeroDeVotos)
            .ToListAsync();

        }
        public async Task<Recurso> ObterPorId(int id)
        {
            return await FindByCondition(recurso => recurso.RecursoId.Equals(id))
            .FirstOrDefaultAsync();
        }
        public void Cadastrar(Recurso recurso)
        {
            Create(recurso);
        }
        public void Atualizar(Recurso recurso)
        {
            Update(recurso);
        }
        public void Remover(Recurso recurso)
        {
            Delete(recurso);
        }
    }
}