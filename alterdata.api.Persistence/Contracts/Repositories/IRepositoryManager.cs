using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace alterdata.api.Persistence.Contracts.Repositories
{
    public interface IRepositoryManager
    {
        IFuncionarioRepository Funcionario { get; }
        IRecursoRepository Recurso { get; }
        IVotacaoRepository Votacao { get; }

        Task SaveAsync();
    }
}
