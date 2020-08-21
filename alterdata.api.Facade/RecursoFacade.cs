using alterdata.api.Domain.Contracts.Services;
using alterdata.api.Facade.Contracts;
using alterdata.api.Persistence.DataTransferObjects.Recurso;
using alterdata.api.Persistence.Entities;
using alterdata.api.Shared.Utils;

using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace alterdata.api.Facade
{
    public class RecursoFacade : IRecursoFacade
    {
        private IRecursoService servico;
        private IMapper mapper;

        public RecursoFacade(IRecursoService servico, IMapper mapper)
        {
            this.servico = servico;
            this.mapper = mapper;
        }

        public async Task<Message<IEnumerable<RecursoDto>>> ObterTodos()
        {
            var message = new Message<IEnumerable<RecursoDto>>();

            try
            {
                var recursos = this.mapper.Map<IEnumerable<RecursoDto>>(await this.servico.ObterTodos());
            
                if (recursos.Any())
                {
                    message.Ok(recursos);
                }

                message.NotFound();
            }
            catch (Exception excecao)
            {
                message.Error(excecao);
            }

            return message;
        }
        public async Task<Message<RecursoDto>> ObterPorId(int id)
        {
            var message = new Message<RecursoDto>();

            try
            {
                var recurso = this.mapper.Map<RecursoDto>(await this.servico.ObterPorId(id));

                if (recurso != null)
                {
                    message.Ok(recurso);
                }

                message.NotFound();
            }
            catch (Exception excecao)
            {
                message.Error(excecao);
            }

            return message;
        }
        public Message Cadastrar(RecursoDto recurso)
        {
            var message = new Message();

            try
            {
                this.servico.Cadastrar(this.mapper.Map<Recurso>(recurso));
                message.Ok();
            }
            catch (Exception exception)
            {
                message.Error(exception);
            }

            return message;
        }
        public Message Atualizar(RecursoDto recurso)
        {
            var message = new Message();

            try
            {
                this.servico.Atualizar(this.mapper.Map<Recurso>(recurso));
                message.Ok();
            }
            catch (Exception exception)
            {
                message.Error(exception);
            }

            return message;
        }
        public Message Remover(RecursoDto recurso)
        {
            var message = new Message();

            try
            {
                this.servico.Remover(this.mapper.Map<Recurso>(recurso));
                message.Ok();
            }
            catch (Exception exception)
            {
                message.Error(exception);
            }

            return message;
        }
    }
}