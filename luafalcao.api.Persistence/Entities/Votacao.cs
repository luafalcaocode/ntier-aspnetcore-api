using System;

namespace luafalcao.api.Persistence.Entities
{
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