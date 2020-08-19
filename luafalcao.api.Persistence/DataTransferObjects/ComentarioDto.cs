using System;
using System.Collections.Generic;
using System.Text;

namespace luafalcao.api.Persistence.DataTransferObjects
{
    public class ComentarioDto
    {
        public int Id { get; set; }
        public string Autor { get; set; }
        public string Descricao { get; set; }
        public DateTime DataPublicacao { get; set; }
    }
}
