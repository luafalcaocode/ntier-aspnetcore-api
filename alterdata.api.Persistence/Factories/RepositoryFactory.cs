﻿using alterdata.api.Persistence.Contexts;
using alterdata.api.Persistence.Enums;
using alterdata.api.Persistence.Repositories;

namespace alterdata.api.Persistence.Factories
{
    public class RepositoryFactory
    {
        public static dynamic Create(RepositoryTypeEnum repositoryType, RepositoryContext context)
        {
            switch(repositoryType)
            {
                case RepositoryTypeEnum.Funcionario:
                    return null;
                case RepositoryTypeEnum.Recurso:
                    return null;
                case RepositoryTypeEnum.Votacao:
                    return null;
            }

            return null;
        }
    }
}