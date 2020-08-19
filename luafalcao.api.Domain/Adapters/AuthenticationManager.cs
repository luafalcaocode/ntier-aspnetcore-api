using System;
using System.Collections;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using luafalcao.api.Domain.Contracts.Adapters;
using luafalcao.api.Persistence.Entities;
using luafalcao.api.Shared.Utils;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace luafalcao.api.Domain.Adapters
{
    public class AuthenticationManager : IAuthenticationManager
    {
        private UserManager<Usuario> userManager;
        private IConfiguration configuration;
        private Usuario usuarioCadastrado;

        public AuthenticationManager(UserManager<Usuario> userManager, IConfiguration configuration)
        {
            this.userManager = userManager;
            this.configuration = configuration;
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

        public async Task<bool> ValidateUser(Usuario usuario)
        {
            this.usuarioCadastrado = await this.userManager.FindByNameAsync(usuario.Email);

            return (this.usuarioCadastrado != null &&
                await this.userManager.CheckPasswordAsync(this.usuarioCadastrado, usuario.Senha));
        }

        public async Task<string> CreateToken()
        {
            var signingCredentials = GetSigningCredentials();
            var claims = await GetClaim();
            var tokenOptions = GenerateTokenOptions(signingCredentials, claims);

            return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        }

        private SigningCredentials GetSigningCredentials()
        {
            var key = Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("SECRET"));
            var secret = new SymmetricSecurityKey(key);

            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }

        private async Task<IList<Claim>> GetClaim()
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, this.usuarioCadastrado.UserName)
            };

            var roles = await this.userManager.GetRolesAsync(this.usuarioCadastrado);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            return claims;
        }

        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, IList<Claim> claims)
        {
            var jwtSettings = this.configuration.GetSection("JwtSettings");
            var tokenOptions = new JwtSecurityToken(
                issuer: jwtSettings.GetSection("validIssuer").Value,
                audience: jwtSettings.GetSection("validAudience").Value,
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(jwtSettings.GetSection("expires").Value)),
                signingCredentials: signingCredentials
                );

            return tokenOptions;
        }
    }
}