using alterdata.api.Persistence.Contracts.Repositories;
using alterdata.api.Persistence.Entities;
using alterdata.api.Persistence.Contexts;

using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;


namespace alterdata.api.Persistence.Repositories
{
    public class FuncionarioRepository : RepositoryBase<Funcionario>, IFuncionarioRepository
    {
        public FuncionarioRepository(RepositoryContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Funcionario>> ObterTodos()
        {
            return await FindAll()
            .OrderBy(funcionario => funcionario.Nome)
            .ToListAsync();

        }
        public async Task<Funcionario> ObterPorId(int id)
        {
            return await FindByCondition(funcionario => funcionario.FuncionarioId.Equals(id))
            .FirstOrDefaultAsync();
        }
        public void Cadastrar(Funcionario funcionario)
        {
            Create(funcionario);
        }
        public void Atualizar(Funcionario funcionario)
        {
            Update(funcionario);
        }
        public void Remover(Funcionario funcionario)
        {
            Delete(funcionario);
        }

    }
}