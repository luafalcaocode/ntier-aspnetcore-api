using System.Threading.Tasks;
using alterdata.api.Persistence.Contexts;
using alterdata.api.Persistence.Contracts.Repositories;
using alterdata.api.Persistence.Enums;
using alterdata.api.Persistence.Factories;

namespace alterdata.api.Persistence.Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private RepositoryContext context;
        private IRecursoRepository recurso;

        public IRecursoRepository Recurso 
        {
            get 
            {
                if (this.recurso == null)
                {
                    this.recurso = RepositoryFactory.Create(RepositoryTypeEnum.Recurso, this.context);
                }

                return this.recurso;
            }
        }
        public RepositoryManager(RepositoryContext context)
        {
            this.context = context;
        }

        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
