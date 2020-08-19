using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using luafalcao.api.Persistence.Contexts;
using luafalcao.api.Persistence.Contracts.Repositories;
using luafalcao.api.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace luafalcao.api.Persistence.Repositories
{
    public class ArtigoRepository : RepositoryBase<Artigo>, IArtigoRepository
    {
        public ArtigoRepository(RepositoryContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Artigo>> GetAllArtigosAsync()
        {
            return await FindAll()
                .OrderBy(filter => filter.DataPublicacao)
                .ToListAsync();
        }

        public async Task<Artigo> GetArtigoWithDetailsAsync(int artigoId)
        {
            return await FindByCondition(filter => filter.Id.Equals(artigoId))
                .Include(a => a.Comentarios)
                .FirstOrDefaultAsync();
        }

        public async Task<Artigo> GetByIdAsync(int artigoId)
        {
            return await FindByCondition(filter => filter.Id.Equals(artigoId))
                .FirstOrDefaultAsync();
        }

        public void CreateArtigo(Artigo entity)
        {
            Create(entity);
        }

        public void DeleteArtigo(Artigo entity)
        {
            Delete(entity);
        }

        public void UpdateArtigo(Artigo entity)
        {
            throw new NotImplementedException();
        }
    }
}
