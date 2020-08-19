using System.Collections.Generic;
using System.Threading.Tasks;
using luafalcao.api.Persistence.DataTransferObjects;

namespace luafalcao.api.Facade.Contracts
{
    public interface IBlogFacade
    {
        Task<IEnumerable<ArtigoDto>> ObterTodosOsArtigos();
        Task<ArtigoDto> ObterArtigoPorId(int id);
    }
}
