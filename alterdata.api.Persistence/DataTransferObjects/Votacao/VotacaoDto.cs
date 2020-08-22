using System;

namespace alterdata.api.Persistence.DataTransferObjects.Votacao
{
    public class VotacaoDto
    {
        public int VotacaoId { get; set; }
        public DateTime DataHora { get; set; }
        public string Comentario { get; set; }
    }
}