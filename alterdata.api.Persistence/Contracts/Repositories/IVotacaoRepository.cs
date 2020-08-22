using System.Threading.Tasks;
using System.Collections.Generic;
using alterdata.api.Persistence.Entities;



namespace alterdata.api.Persistence.Contracts.Repositories
{
    public interface IVotacaoRepository
    {
         void Cadastrar(Votacao voto);
         Task<IEnumerable<Votacao>> ObterTodos();
    }
}