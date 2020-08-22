using alterdata.api.Persistence.Contracts.Repositories;
using alterdata.api.Persistence.Entities;
using alterdata.api.Persistence.Contexts;

using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace alterdata.api.Persistence.Repositories
{
    public class VotacaoRepository : RepositoryBase<Votacao>, IVotacaoRepository
    {
        public VotacaoRepository(RepositoryContext context) : base(context)
        {

        }

        public void Cadastrar(Votacao voto)
        {
            Create(voto);
        }

        public async Task<IEnumerable<Votacao>> ObterTodos()
        {
            return await FindAll().ToListAsync();
        }
    }
}