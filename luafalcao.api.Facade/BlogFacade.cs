using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using luafalcao.api.Domain.Contracts;
using luafalcao.api.Facade.Contracts;
using luafalcao.api.Persistence.DataTransferObjects;

namespace luafalcao.api.Facade
{
    public class BlogFacade : IBlogFacade
    {
        private IArtigoService artigoService;
        private IMapper mapper;

        public BlogFacade(IArtigoService artigoService, IMapper mapper)
        {
            this.artigoService = artigoService;

            this.mapper = mapper;
        }

        public async Task<IEnumerable<ArtigoDto>> ObterTodosOsArtigos()
        {
            return this.mapper.Map<IEnumerable<ArtigoDto>>(await artigoService.ObterTodos());
        }
            

        public async Task<ArtigoDto> ObterArtigoPorId(int id)
        {
            return this.mapper.Map<ArtigoDto>(await this.artigoService.ObterArtigoPorId(id));
        }
    }
}
