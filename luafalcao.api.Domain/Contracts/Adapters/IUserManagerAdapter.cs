using System.Threading.Tasks;
using luafalcao.api.Persistence.Entities;
using luafalcao.api.Shared.Utils;

namespace luafalcao.api.Domain.Contracts.Adapters
{
    public interface IUserManagerAdapter
    {
        Task<Message<Usuario>> RegisterUser(Usuario usuario);
    }
}