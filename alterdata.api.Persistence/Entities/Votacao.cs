using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace alterdata.api.Persistence.Entities
{
    [Table("Votacao")]
    public class Votacao
    {
        public int VotacaoId { get; set; }
        public DateTime DataHora { get; set; }
        public string Comentario { get; set; }

        public int FuncionarioId { get; set; }
        public Funcionario Funcionario { get; set; }
        public int RecursoId { get; set; }
        public Recurso Recurso { get; set; }
    }
}