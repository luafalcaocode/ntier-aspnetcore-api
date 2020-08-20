using alterdata.api.Persistence.Contracts.Strategies;
using alterdata.api.Persistence.Enums;
using alterdata.api.Persistence.Strategies;

namespace alterdata.api.Persistence.Factories
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