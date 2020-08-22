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
        public async Task Cadastrar(Funcionario recurso)
        {
            this.repositorio.Funcionario.Cadastrar(recurso);
            await this.repositorio.SaveAsync();
        }
        public async Task Atualizar(Funcionario recurso)
        {
            this.repositorio.Funcionario.Atualizar(recurso);
            await this.repositorio.SaveAsync();
        }
        public async Task Remover(Funcionario recurso)
        {
            this.repositorio.Funcionario.Remover(recurso);
            await this.repositorio.SaveAsync();
        }


    }
}