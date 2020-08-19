using luafalcao.api.Persistence.Contexts;
using luafalcao.api.Persistence.Enums;
using luafalcao.api.Persistence.Repositories;

namespace luafalcao.api.Persistence.Factories
{
    public class RepositoryFactory
    {
        public static dynamic Create(RepositoryTypeEnum repositoryType, RepositoryContext context)
        {
            switch(repositoryType)
            {
                case RepositoryTypeEnum.Artigo:
                    return new ArtigoRepository(context);
            }

            return null;
        }
    }
}
