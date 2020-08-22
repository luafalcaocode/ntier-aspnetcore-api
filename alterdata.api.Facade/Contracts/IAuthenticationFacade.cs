using alterdata.api.Persistence.DataTransferObjects;
using alterdata.api.Persistence.DataTransferObjects.Usuario;
using alterdata.api.Shared.Utils;

using System.Threading.Tasks;

namespace alterdata.api.Facade.Contracts
{
    public interface IAuthenticationFacade
    {
        Task<Message> RegisterUser(UsuarioCadastroDto usuarioDto);
        Task<Message<string>> Login(UsuarioAutenticacaoDto usuarioDto);
    }
}