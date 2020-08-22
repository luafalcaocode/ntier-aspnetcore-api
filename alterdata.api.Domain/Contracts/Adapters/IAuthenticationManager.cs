using System.Threading.Tasks;
using alterdata.api.Persistence.Entities;
using alterdata.api.Shared.Utils;

namespace alterdata.api.Domain.Contracts.Adapters
{
    public interface IAuthenticationManager
    {
        Task<Message> RegisterUser(Usuario usuario);
        Task<bool> ValidateUser(Usuario usuario);
        Task<Usuario> GetUserByUserName(string username);

        Task<string> CreateToken();
        
    }
}