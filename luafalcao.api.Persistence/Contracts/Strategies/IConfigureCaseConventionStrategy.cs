using Microsoft.EntityFrameworkCore;

namespace luafalcao.api.Persistence.Contracts.Strategies
{
    public interface IConfigureCaseConventionStrategy
    {
         void Configure(ModelBuilder builder);
    }
}