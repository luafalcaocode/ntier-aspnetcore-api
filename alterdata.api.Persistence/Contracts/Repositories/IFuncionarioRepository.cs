using System.Threading.Tasks;
using System.Collections.Generic;
using alterdata.api.Persistence.Entities;


namespace alterdata.api.Persistence.Contracts.Repositories
{
    public interface IFuncionarioRepository : IRepositoryBase<Funcionario>
    {
        Task<IEnumerable<Funcionario>> ObterTodos();
        Task<Funcionario> ObterPorId(int id);
        void Cadastrar(Funcionario recurso);
        void Atualizar(Funcionario recurso);
        void Remover(Funcionario recurso);
    }
}