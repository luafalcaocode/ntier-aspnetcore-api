using alterdata.api.Persistence.Entities;

using System.Collections.Generic;
using System.Threading.Tasks;


namespace alterdata.api.Domain.Contracts.Services
{
    public interface IFuncionarioService
    {
        Task<IEnumerable<Funcionario>> ObterTodos();
        Task<Funcionario> ObterPorId(int id);
        Task Cadastrar(Funcionario recurso);
        Task Atualizar(Funcionario recurso);
        Task Remover(Funcionario recurso);
    }
}