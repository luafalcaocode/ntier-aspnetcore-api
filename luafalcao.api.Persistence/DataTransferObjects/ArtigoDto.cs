using System;
using System.Collections.Generic;
using System.Text;

namespace luafalcao.api.Persistence.DataTransferObjects
{
    public class ArtigoDto
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string DataPublicacao { get; set; }
        public string Descricao { get; set; }
        public byte[] Thumbnail { get; set; }
        public string Link { get; set; }
        public string Tags { get; set; }
    }
}
