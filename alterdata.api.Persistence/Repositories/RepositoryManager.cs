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
        private IFuncionarioRepository funcionario;
        private IRecursoRepository recurso;
        private IVotacaoRepository votacao;

        public IFuncionarioRepository Funcionario 
        {
            get 
            {
                if (this.funcionario == null) {
                    this.funcionario = RepositoryFactory.Create(RepositoryTypeEnum.Funcionario, this.context);
                }

                return this.funcionario;
            }
        }

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

        public IVotacaoRepository Votacao 
        {
            get 
            {
                if (this.votacao == null)
                {
                    this.votacao = RepositoryFactory.Create(RepositoryTypeEnum.Votacao, this.context);
                }

                return this.votacao;
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
