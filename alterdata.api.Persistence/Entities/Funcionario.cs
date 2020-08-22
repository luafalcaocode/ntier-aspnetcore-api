using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace alterdata.api.Persistence.Entities
{
    [Table("Funcionario")]
    public class Funcionario 
    {
        public int FuncionarioId { get; set; }        
        public string Nome { get; set; }
        public string Email { get; set; }

        public string UfDaFilialOndeTrabalha { get; set; }

        public Votacao Votacao { get; set; }
        public string UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
    }
}