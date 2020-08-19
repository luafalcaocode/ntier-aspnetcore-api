using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace luafalcao.api.Persistence.DataTransferObjects.Usuario
{
    public class UsuarioCadastroDto
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public ICollection<string> Perfis { get; set; }
    }
}