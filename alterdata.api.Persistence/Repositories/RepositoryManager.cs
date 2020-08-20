using System.Threading.Tasks;
using alterdata.api.Persistence.Contexts;
using alterdata.api.Persistence.Contracts.Repositories;
using alterdata.api.Persistence.Enums;
using alterdata.api.Persistence.Factories;

namespace alterdata.api.Persistence.Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private RepositoryContext _repositoryContext;

        public RepositoryManager(RepositoryContext context)
        {
            _repositoryContext = context;
        }

        public async Task SaveAsync()
        {
            await _repositoryContext.SaveChangesAsync();
        }
    }
}
