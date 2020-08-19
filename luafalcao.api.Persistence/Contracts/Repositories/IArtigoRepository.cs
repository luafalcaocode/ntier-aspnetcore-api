using luafalcao.api.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace luafalcao.api.Persistence.Contracts.Repositories
{
    public interface IArtigoRepository : IRepositoryBase<Artigo>
    {
        Task<IEnumerable<Artigo>> GetAllArtigosAsync();
        Task<Artigo> GetByIdAsync(int artigoId);
        Task<Artigo> GetArtigoWithDetailsAsync(int artigoId);

        void CreateArtigo(Artigo entity);
        void UpdateArtigo(Artigo entity);
        void DeleteArtigo(Artigo entity);        
    }
}
