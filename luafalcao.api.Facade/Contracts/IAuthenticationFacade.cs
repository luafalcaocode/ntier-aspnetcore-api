using luafalcao.api.Persistence.DataTransferObjects;
using luafalcao.api.Shared.Utils;

using System.Threading.Tasks;

namespace luafalcao.api.Facade.Contracts
{
    public interface IAuthenticationFacade
    {
         Task<Message<UsuarioDto>> RegisterUser(UsuarioDto usuario);
    }
}