using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;


namespace alterdata.api.Persistence.Entities
{
    public class Funcionario 
    {
        public int FuncionarioId { get; set; }        
        public string Nome { get; set; }
        public string Email { get; set; }

        public string Filial { get; set; }

        public Votacao Votacao { get; set; }
        public string UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
    }
}