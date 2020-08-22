using alterdata.api.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;



namespace alterdata.api.Domain.Contracts.Services
{
    public interface IVotacaoService
    {
        Task<IEnumerable<Votacao>> ObterTodos();
        Task Cadastrar(Votacao voto);
        DateTime ObterHoraDoVotoPorRegiao(string filial);
    }
}