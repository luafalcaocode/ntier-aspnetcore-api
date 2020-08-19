using luafalcao.api.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace luafalcao.api.Persistence.Configurations
{
    public class ComentarioConfiguration : IEntityTypeConfiguration<Comentario>
    {
        public void Configure(EntityTypeBuilder<Comentario> builder)
        {
            builder.HasData(new Comentario
            {
                Id = 1,
                Descricao = "Adorei o Artigo! Parabéns!",
                Autor = "Jaina Proudmore",
                DataPublicacao = new DateTime().AddDays(10),
                ArtigoId = 1
            },
            new Comentario
            {
                Id = 2,
                Descricao = "Não concordo com o que você escreveu sobre o Adapter! Ele é mais complexo do que isso! Mas boa tentativa!!",
                Autor = "Iena Hard",
                DataPublicacao = new DateTime().AddDays(5),
                ArtigoId = 1
            },
            new Comentario
            {
                Id = 3,
                Descricao = "Padrões de projeto são muito importantes!! Espero que no futuro mais programadores façam uso deles para criar soluções de valor!",
                Autor = "Tron",
                DataPublicacao = new DateTime().AddDays(6),
                ArtigoId = 2
            });
        }
    }
}
