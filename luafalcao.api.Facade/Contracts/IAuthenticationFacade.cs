using luafalcao.api.Persistence.DataTransferObjects;
using luafalcao.api.Persistence.DataTransferObjects.Usuario;
using luafalcao.api.Shared.Utils;

using System.Threading.Tasks;

namespace luafalcao.api.Facade.Contracts
{
    public interface IAuthenticationFacade
    {
        Task<Message<UsuarioCadastroDto>> RegisterUser(UsuarioCadastroDto usuario);
        Task<Message<string>> Login(UsuarioAutenticacaoDto usuarioDto);
    }
}