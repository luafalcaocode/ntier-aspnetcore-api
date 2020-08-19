using System.Threading.Tasks;
using luafalcao.api.Persistence.Contexts;
using luafalcao.api.Persistence.Contracts.Repositories;
using luafalcao.api.Persistence.Enums;
using luafalcao.api.Persistence.Factories;

namespace luafalcao.api.Persistence.Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private RepositoryContext _repositoryContext;
        private IArtigoRepository _artigoRepository;

        public RepositoryManager(RepositoryContext context)
        {
            _repositoryContext = context;
        }

        public IArtigoRepository Artigo
        {
            get
            {
                if (_artigoRepository == null)
                {
                    _artigoRepository = RepositoryFactory.Create(RepositoryTypeEnum.Artigo, _repositoryContext);
                }

                return _artigoRepository;                
            }
        }

        public async Task SaveAsync()
        {
            await _repositoryContext.SaveChangesAsync();
        }
    }
}
