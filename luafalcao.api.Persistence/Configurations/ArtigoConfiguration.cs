using luafalcao.api.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace luafalcao.api.Persistence.Configurations
{
   public class ArtigoConfiguration : IEntityTypeConfiguration<Artigo>
    {
        public void Configure(EntityTypeBuilder<Artigo> builder)
        {
            builder.HasData(new Artigo
            {
                Id = 1,
                Titulo = "Design Patterns #5: Adapter",
                DataPublicacao = new DateTime(),
                Descricao = "Chegou a vez do padrão de projetos Adapter! Vamos ver como usá-lo para tornar o nosso código mais flexível",
                NumeroLikes = 5,
                Tags = string.Concat("DIARIO-ENGENHEIRO-SOFTWARE")                
            },
            new Artigo
            {
                Id = 2,
                Titulo = "Padrões de Projeto e onde habitam",
                DataPublicacao = new DateTime(),
                Descricao = "Padrões de projeto são soluções flexíveis e reutilizáveis para problemas frequentes no dia a dia do programador...",
                NumeroLikes = 10,
                Tags = string.Concat("DIARIO-ENGENHEIRO-SOFTWARE")
            }) ;
        }        
    }
}
