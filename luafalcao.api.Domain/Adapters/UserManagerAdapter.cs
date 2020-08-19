using System.Threading.Tasks;
using luafalcao.api.Domain.Contracts.Adapters;
using luafalcao.api.Persistence.Entities;
using luafalcao.api.Shared.Utils;
using Microsoft.AspNetCore.Identity;

namespace luafalcao.api.Domain.Adapters
{
    public class UserManagerAdapter : IUserManagerAdapter
    {
        private UserManager<Usuario> userManager;

        public UserManagerAdapter(UserManager<Usuario> userManager)
        {
            this.userManager = userManager;
        }

        public async Task<Message<Usuario>> RegisterUser(Usuario usuario)
        {
            var message = new Message<Usuario>();

            var result = await this.userManager.CreateAsync(usuario, usuario.Senha);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    message.Errors.Add(error.Description);
                }

                return message;
            }


            await this.userManager.AddToRolesAsync(usuario, usuario.Perfis);
            message.Success = true;
            
            return message;
        }
    }
}