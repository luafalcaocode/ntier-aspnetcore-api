using luafalcao.api.Persistence.Contracts.Strategies;
using luafalcao.api.Persistence.Enums;
using luafalcao.api.Persistence.Strategies;

namespace luafalcao.api.Persistence.Factories
{
    public static class CaseConventionStrategyFactory
    {
        public static IConfigureCaseConventionStrategy Create(CaseConventionEnum conventionType) 
        {
            switch(conventionType)
            {
                case CaseConventionEnum.SnakeCase:
                    return new SnakeCaseConventionStrategy();
            }

            return null;
        }
    }
}