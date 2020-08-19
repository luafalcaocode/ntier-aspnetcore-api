using System;
using System.Collections.Generic;
using System.Text;
using luafalcao.api.Persistence.Entities;

namespace luafalcao.api.Persistence.Contracts.Repositories
{
    public interface IComentarioRepository : IRepositoryBase<Comentario>
    {
        IEnumerable<Comentario> ObterTodos();
    }
}
