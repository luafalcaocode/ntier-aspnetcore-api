

namespace alterdata.api.Persistence.DataTransferObjects.Funcionario
{
    public class FuncionarioDto
    {
        public int FuncionarioId { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string UfDaFilialOndeTrabalha { get; set; }
    }
}