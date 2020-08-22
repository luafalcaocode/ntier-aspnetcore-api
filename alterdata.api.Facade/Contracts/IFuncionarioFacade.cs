using alterdata.api.Persistence.DataTransferObjects;
using alterdata.api.Persistence.DataTransferObjects.Funcionario;
using alterdata.api.Persistence.DataTransferObjects.Usuario;
using alterdata.api.Shared.Utils;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace alterdata.api.Facade.Contracts
{
    public interface IFuncionarioFacade
    {
        Task<Message<IEnumerable<FuncionarioDto>>> ObterTodos();
        Task<Message<FuncionarioDto>> ObterPorId(int id);
        Task<Message> Cadastrar(FuncionarioDto recurso);
        Task<Message> Atualizar(FuncionarioDto recurso);
        Task<Message> Remover(FuncionarioDto recurso);
    }
}