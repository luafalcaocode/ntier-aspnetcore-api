using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Text;

namespace luafalcao.api.Persistence.Entities
{
    [Table("Comentario")]
    public class Comentario
    {
        public int Id { get; set; }
        public string Autor { get; set; }
        public string Descricao { get; set; }
        public DateTime DataPublicacao { get; set; }
        public string Email { get; set; }


        [ForeignKey(nameof(Artigo))]
        public virtual int ArtigoId { get; set; }
        public virtual Artigo Artigo { get; set; }

    }
}
