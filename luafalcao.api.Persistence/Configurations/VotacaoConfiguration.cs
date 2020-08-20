using luafalcao.api.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;


namespace luafalcao.api.Persistence.Configurations
{
    public class VotacaoConfiguration : IEntityTypeConfiguration<Votacao>
    {
        public void Configure(EntityTypeBuilder<Votacao> builder)
        {
            builder.HasData(
                new Votacao
                {
                    VotacaoId = 1,
                    DataHora = DateTime.Now,
                    Comentario = "Este recurso é importante para o cliente",
                    RecursoId = 1,
                    FuncionarioId = 1
                }
            );
        }

    }
}