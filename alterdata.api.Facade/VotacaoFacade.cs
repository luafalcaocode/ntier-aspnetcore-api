using alterdata.api.Domain.Contracts.Services;
using alterdata.api.Facade.Contracts;
using alterdata.api.Persistence.DataTransferObjects.Recurso;
using alterdata.api.Persistence.DataTransferObjects.Votacao;
using alterdata.api.Persistence.Entities;
using alterdata.api.Shared.Utils;

using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace alterdata.api.Facade
{
    public class VotacaoFacade : IVotacaoFacade
    {
        private IVotacaoService votacaoService;
        private IFuncionarioService funcionarioService;
        private IMapper mapper;

        public VotacaoFacade(IVotacaoService votacaoService, IFuncionarioService funcionarioService, IMapper mapper)
        {
            this.votacaoService = votacaoService;
            this.funcionarioService = funcionarioService;
            this.mapper = mapper;
        }

        public async Task<Message> Votar(VotacaoCadastroDto votoDto)
        {
            var message = new Message();

            try 
            {
                var funcionario = await this.funcionarioService.ObterPorId(votoDto.FuncionarioId);
                
                if (funcionario == null)
                {
                    message.Validations.Add("O id do funcionário informado não existe.");
                    message.BadRequest();

                    return message;
                }

                if (await this.votacaoService.VerificarSeFuncionarioJaVotou(funcionario.FuncionarioId))
                {
                    message.Validations.Add($"O funcionário {funcionario.Nome} com id {funcionario.FuncionarioId} já votou em um recurso e portanto não poderá votar novamente.");
                    message.BadRequest();

                    return message;
                }

                var dataHoraDaVotacao = this.votacaoService.ObterDataHoraDoVotoPorRegiao(funcionario.UfDaFilialOndeTrabalha);
                var voto = this.mapper.Map<Votacao>(votoDto);
                voto.DataHora = dataHoraDaVotacao;

                await this.votacaoService.Cadastrar(voto);
                
                message.Created();
            }
            catch(Exception exception)
            {
                message.Error(exception);
            }

            return message;
        }

        public async Task<Message<IEnumerable<VotacaoDto>>> ObterTodos()
        {
            var message = new Message<IEnumerable<VotacaoDto>>();

            try 
            {
                var voto = this.mapper.Map<IEnumerable<VotacaoDto>>(await this.votacaoService.ObterTodos());
                
                if (!voto.Any())
                {
                    message.NotFound();
                    return message;
                }

                message.Ok(voto);
            }
            catch(Exception exception)
            {
                message.Error(exception);
            }

            return message;
        }
    }
}