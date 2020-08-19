using System.Collections.Generic;
using System.Threading.Tasks;
using luafalcao.api.Persistence.Entities;

namespace luafalcao.api.Domain.Contracts
{
    public interface IArtigoService
    {
        Task<IEnumerable<Artigo>> ObterTodos();
        Task<Artigo> ObterArtigoPorId(int id);
    }
}
