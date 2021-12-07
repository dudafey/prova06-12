using System;

namespace Prova.API.ViewModels.Funcionario {
    public class FuncionarioResponseViewModel {
        public int Id { get; set; }
        public DateTime CriadoEm { get; set; }
        public DateTime AtualizadoEm { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public decimal Matricula { get; set; }
    }
}
