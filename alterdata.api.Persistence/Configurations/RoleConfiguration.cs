using alterdata.api.Persistence.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace alterdata.api.Persistence.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(new IdentityRole
            {
                Name = "Administrador",
                NormalizedName = "Administrador"
            },
            new IdentityRole
            {
                Name = "Todos",
                NormalizedName = "Todos"
            });
        }
    }
}
