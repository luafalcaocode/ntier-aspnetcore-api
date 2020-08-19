
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Text;

namespace luafalcao.api.Persistence.Entities
{
    [Table("Artigo")]
    public class Artigo
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public byte[] Thumbnail { get; set; }
        public DateTime DataPublicacao { get; set; }
        public string Link { get; set; }
        public string Tags { get; set; }
        public int NumeroLikes { get; set; }

        public virtual ICollection<Comentario> Comentarios { get; set; }
    }
}
