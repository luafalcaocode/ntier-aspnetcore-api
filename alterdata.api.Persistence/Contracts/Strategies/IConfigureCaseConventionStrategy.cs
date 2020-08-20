using Microsoft.EntityFrameworkCore;

namespace alterdata.api.Persistence.Contracts.Strategies
{
    public interface IConfigureCaseConventionStrategy
    {
         void Configure(ModelBuilder builder);
    }
}