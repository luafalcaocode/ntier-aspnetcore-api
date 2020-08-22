using alterdata.api.Domain.Contracts.Services;
using alterdata.api.Persistence.Contracts.Repositories;
using alterdata.api.Persistence.Entities;

using System.Collections.Generic;
using System.Threading.Tasks;


namespace alterdata.api.Domain.Services
{
    public class FuncionarioService : IFuncionarioService
    {
        private IRepositoryManager repositorio;

        public FuncionarioService(IRepositoryManager repositorio)
        {
            this.repositorio = repositorio;
        }

        public async Task<IEnumerable<Funcionario>> ObterTodos()
        {
            return await this.repositorio.Funcionario.ObterTodos();
        }
        public async Task<Funcionario> ObterPorId(int id)
        {
            return await this.repositorio.Funcionario.ObterPorId(id);
        }
        public async Task Cadastrar(Funcionario funcionario)
        {
            this.repositorio.Funcionario.Cadastrar(funcionario);
            await this.repositorio.SaveAsync();
        }
        public async Task Atualizar(Funcionario funcionario)
        {
            this.repositorio.Funcionario.Atualizar(funcionario);
            await this.repositorio.SaveAsync();
        }
        public async Task Remover(Funcionario funcionario)
        {
            this.repositorio.Funcionario.Remover(funcionario);
            await this.repositorio.SaveAsync();
        }


    }
}