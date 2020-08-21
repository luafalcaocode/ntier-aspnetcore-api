using System.Collections.Generic;

namespace alterdata.api.Persistence.Entities
{
    public class Recurso 
    {
        public int RecursoId { get; set; }
        public string Nome { get; set; }
        public int NumeroDeVotos { get; set; }

        public ICollection<Votacao> Votacoes {get;set;}
    }
}