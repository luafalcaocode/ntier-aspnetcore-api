using System.Threading.Tasks;
using alterdata.api.Persistence.Entities;
using alterdata.api.Shared.Utils;

namespace alterdata.api.Domain.Contracts.Adapters
{
    public interface IAuthenticationManager
    {
        Task<Message<Usuario>> RegisterUser(Usuario usuario);
        Task<bool> ValidateUser(Usuario usuario);

        Task<string> CreateToken();
        
    }
}