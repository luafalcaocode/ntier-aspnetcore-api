using alterdata.api.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace alterdata.api.Persistence.Configurations
{
    public class RecursoConfiguration : IEntityTypeConfiguration<Recurso>
    {
        public void Configure(EntityTypeBuilder<Recurso> builder)
        {
            //builder.HasMany<Votacao>()
            //    .WithOne(votacao => votacao.Recurso)
            //    .HasForeignKey(s => s.RecursoId);

            //builder.HasData(
            //    new Recurso
            //    {
            //        RecursoId = 1,
            //        Nome = "Push Notifications",
            //        NumeroDeVotos = 1,
            //    },
            //    new Recurso
            //    {
            //        RecursoId = 2,
            //        Nome = "Pagamento usando cartão de crédito e boleto bancário",
            //        NumeroDeVotos = 0,
            //    },
            //    new Recurso
            //    {
            //        RecursoId = 3,
            //        Nome = "Leitura de código de barras para realizar compras",
            //        NumeroDeVotos = 0,
            //    }
            //);
        }
    }
}