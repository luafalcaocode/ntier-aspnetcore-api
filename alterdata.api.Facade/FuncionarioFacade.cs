using alterdata.api.Domain.Contracts.Adapters;
using alterdata.api.Domain.Contracts.Services;
using alterdata.api.Facade.Contracts;
using alterdata.api.Persistence.DataTransferObjects.Funcionario;
using alterdata.api.Persistence.DataTransferObjects.Usuario;
using alterdata.api.Persistence.Entities;
using alterdata.api.Shared.Utils;

using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace alterdata.api.Facade
{
    public class FuncionarioFacade : IFuncionarioFacade
    {
        private IFuncionarioService servico;
        private IAuthenticationManager authenticationManager;
        private IMapper mapper;

        public FuncionarioFacade(IFuncionarioService servico, IAuthenticationManager authenticationManager, IMapper mapper)
        {
            this.servico = servico;
            this.authenticationManager = authenticationManager;
            this.mapper = mapper;
        }

        public async Task<Message<IEnumerable<FuncionarioDto>>> ObterTodos()
        {
            var message = new Message<IEnumerable<FuncionarioDto>>();

            try
            {
                var funcionarios = this.mapper.Map<IEnumerable<FuncionarioDto>>(await this.servico.ObterTodos());

                if (funcionarios.Any())
                {
                    message.Ok(funcionarios);
                }

                message.NotFound();
            }
            catch (Exception excecao)
            {
                message.Error(excecao);
            }

            return message;
        }
        public async Task<Message<FuncionarioDto>> ObterPorId(int id)
        {
            var message = new Message<FuncionarioDto>();

            try
            {
                var funcionario = this.mapper.Map<FuncionarioDto>(await this.servico.ObterPorId(id));

                if (funcionario != null)
                {
                    message.Ok(funcionario);
                }

                message.NotFound();
            }
            catch (Exception excecao)
            {
                message.Error(excecao);
            }

            return message;
        }
        public async Task<Message> Cadastrar(FuncionarioDto funcionario)
        {
            var message = new Message();

            try
            {
                var novoUsuario = this.mapper.Map<Usuario>(funcionario);
                var usuarioCadastrado = await this.authenticationManager.RegisterUser(novoUsuario);
                var novoFuncionario = this.mapper.Map<Funcionario>(funcionario);
              
                novoFuncionario.UsuarioId = usuarioCadastrado.Data.Id;

                await this.servico.Cadastrar(novoFuncionario);
                
                message.Ok();
            }
            catch (Exception exception)
            {
                message.Error(exception);
            }

            return message;
        }
        public async Task<Message> Atualizar(FuncionarioDto funcionario)
        {
            var message = new Message();

            try
            {
                await this.servico.Atualizar(this.mapper.Map<Funcionario>(funcionario));
                message.Ok();
            }
            catch (Exception exception)
            {
                message.Error(exception);
            }

            return message;
        }
        public async Task<Message> Remover(FuncionarioDto funcionario)
        {
            var message = new Message();

            try
            {
                await this.servico.Remover(this.mapper.Map<Funcionario>(funcionario));
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