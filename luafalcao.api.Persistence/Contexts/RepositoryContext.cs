using luafalcao.api.Persistence.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace luafalcao.api.Persistence.Contexts
{
    public class RepositoryContext : IdentityDbContext<Usuario>
    {
        public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options)
        {
        }

        public RepositoryContext()
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }

        public DbSet<Artigo> Artigos { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }
    }
}
