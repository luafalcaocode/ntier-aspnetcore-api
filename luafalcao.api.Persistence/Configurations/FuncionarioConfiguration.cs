using luafalcao.api.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace luafalcao.api.Persistence.Configurations
{
    public class FuncionarioConfiguration : IEntityTypeConfiguration<Funcionario>
    {
        public void Configure(EntityTypeBuilder<Funcionario> builder)
        {
            builder.HasData(new Funcionario
            {
                Nome = "Luã Falcão",
                Email = "superadmin@email.com",
                FuncionarioId = 1,
                UsuarioId = "9e203a7a-55ac-4186-9a2b-2e0961235316"
            });
        }
    }
}