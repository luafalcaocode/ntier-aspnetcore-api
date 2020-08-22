using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using alterdata.api.Domain.Contracts.Services;
using alterdata.api.Persistence.Contracts.Repositories;
using alterdata.api.Persistence.Entities;
using alterdata.api.Shared.Utils;

namespace alterdata.api.Domain.Services
{
    public class VotacaoService : IVotacaoService
    {
        private IRepositoryManager repositorio;

        public VotacaoService(IRepositoryManager repositorio)
        {
            this.repositorio = repositorio;
        }

        public async Task Cadastrar(Votacao voto)
        {
            this.repositorio.Votacao.Cadastrar(voto);
            await this.repositorio.SaveAsync();

        }

        public async Task<IEnumerable<Votacao>> ObterTodos()
        {
            return await this.repositorio.Votacao.ObterTodos();
        }

        public DateTime ObterDataHoraDoVotoPorRegiao(string filial)
        {
            FusoHorarioUtils fuso = new FusoHorarioUtils();

            foreach (var item in fuso.dicionario)
            {
                if (filial.Equals(item.Key.ToString()))
                {
                    return DateTime.Now.AddHours(Convert.ToDouble(item.Value));
                }
            }

            return DateTime.Now;
        }

        public async Task<bool> VerificarSeFuncionarioJaVotou(int funcionarioId)
        {
            var votos = await this.repositorio.Votacao.ObterTodos();

            return votos.Where(voto => voto.FuncionarioId.Equals(funcionarioId)).Any();
        }
    }
}