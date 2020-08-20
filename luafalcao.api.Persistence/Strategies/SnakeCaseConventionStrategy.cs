using luafalcao.api.Persistence.Contracts.Strategies;
using luafalcao.api.Shared.Formatters;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace luafalcao.api.Persistence.Strategies
{
    public class SnakeCaseConventionStrategy : IConfigureCaseConventionStrategy
    {
        public void Configure(ModelBuilder builder)
        {
            var entityTypes = builder.Model.GetEntityTypes().ToList();

            entityTypes.ForEach(entity =>
            {
                entity.SetTableName(entity.GetTableName().ToSnakeCase());

                entity.GetProperties().ToList().ForEach(property =>
                {
                    property.SetColumnName(property.GetColumnName().ToSnakeCase());
                });

                entity.GetKeys().ToList().ForEach(key =>
                {
                    key.SetName(key.GetName().ToSnakeCase());
                });

                entity.GetForeignKeys().ToList().ForEach(key =>
                {
                    key.SetConstraintName(key.GetConstraintName().ToSnakeCase());
                });

                entity.GetIndexes().ToList().ForEach(index =>
                {
                    index.GetName().ToSnakeCase();
                });
            });
        }
    }
}