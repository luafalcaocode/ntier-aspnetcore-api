using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace alterdata.api.Persistence.Entities
{
    [Table("Recurso")]
    public class Recurso 
    {
        public int RecursoId { get; set; }
        public string Nome { get; set; }
        public int NumeroDeVotos { get; set; }

        public ICollection<Votacao> Votacoes {get;set;}
    }
}