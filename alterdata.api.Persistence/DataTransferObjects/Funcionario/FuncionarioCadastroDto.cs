using System.Collections;
using System.Collections.Generic;

namespace alterdata.api.Persistence.DataTransferObjects.Funcionario
{
    public class FuncionarioCadastroDto
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string UfDaFilialOndeTrabalha { get; set; }

        public IList<string> Perfis { get; set; }
    }
}