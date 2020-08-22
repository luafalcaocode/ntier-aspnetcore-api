using System;

namespace alterdata.api.Persistence.DataTransferObjects.Votacao
{
    public class VotacaoCadastroDto
    {
        public string Comentario { get; set; }
        public int FuncionarioId { get; set; }
        public int RecursoId { get; set; }
    }
}