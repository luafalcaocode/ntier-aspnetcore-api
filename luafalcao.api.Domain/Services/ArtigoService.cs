using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using luafalcao.api.Domain.Contracts;
using luafalcao.api.Persistence.Contracts.Repositories;
using luafalcao.api.Persistence.Entities;
using luafalcao.api.Persistence.Repositories;

namespace luafalcao.api.Domain.Services
{
    public class ArtigoService : IArtigoService
    {
        private IRepositoryManager repository;

        public ArtigoService(IRepositoryManager repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<Artigo>> ObterTodos()
        {
            return await this.repository.Artigo.GetAllArtigosAsync();
        }


        public async Task<Artigo> ObterArtigoPorId(int id)
        {
            return await this.repository.Artigo.GetByIdAsync(id);
        }

    }
}
