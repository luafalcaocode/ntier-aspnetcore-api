using alterdata.api.Domain.Contracts.Services;
using alterdata.api.Persistence.Contracts.Repositories;
using alterdata.api.Persistence.Entities;

using System.Collections.Generic;
using System.Threading.Tasks;


namespace alterdata.api.Domain.Services
{
    public class RecursoService : IRecursoService
    {
        private IRepositoryManager repositorio;

        public RecursoService(IRepositoryManager repositorio)
        {
            this.repositorio = repositorio;
        }

        public async Task<IEnumerable<Recurso>> ObterTodos()
        {
            return await this.repositorio.Recurso.ObterTodos();
        }
        public async Task<Recurso> ObterPorId(int id)
        {
            return await this.repositorio.Recurso.ObterPorId(id);
        }
        public async Task Cadastrar(Recurso recurso)
        {
            this.repositorio.Recurso.Cadastrar(recurso);
            await this.repositorio.SaveAsync();
        }
        public async Task Atualizar(Recurso recurso)
        {
            this.repositorio.Recurso.Atualizar(recurso);
            await this.repositorio.SaveAsync();
        }
        public async Task Remover(Recurso recurso)
        {
            this.repositorio.Recurso.Remover(recurso);
            await this.repositorio.SaveAsync();
        }
    }
}