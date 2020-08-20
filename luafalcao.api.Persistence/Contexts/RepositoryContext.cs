﻿using luafalcao.api.Persistence.Contracts.Strategies;
using luafalcao.api.Persistence.Factories;
using luafalcao.api.Persistence.Entities;
using luafalcao.api.Persistence.Enums;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace luafalcao.api.Persistence.Contexts
{
    public class RepositoryContext : IdentityDbContext<Usuario>
    {
        private IConfigureCaseConventionStrategy caseConventionStrategy;

        public RepositoryContext(DbContextOptions<RepositoryContext> options)
            : base(options)
        {
            this.caseConventionStrategy = CaseConventionStrategyFactory.Create(CaseConventionEnum.SnakeCase);
        }

        public RepositoryContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            this.caseConventionStrategy.Configure(builder);
            builder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }

        public DbSet<Recurso> Recursos { get; set; }
        public DbSet<Votacao> Votacao { get; set; }
        public DbSet<Funcionario> Funcionario { get; set; }
    }
}
