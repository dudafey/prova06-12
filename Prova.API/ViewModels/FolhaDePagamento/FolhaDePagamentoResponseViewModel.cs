using System;

namespace Prova.API.ViewModels.FolhaDePagamento {
    public class FolhaDePagamentoResponseViewModel {
        public int Id { get; set; }
        public DateTime CriadoEm { get; set; }
        public DateTime AtualizadoEm { get; set; }
        public int IdFuncionario { get; set; }
        public decimal HorasTrabalhadas { get; set; }
        public decimal ValorHora { get; set; }
        public int Ano { get; set; }
        public int Mes { get; set; }
    }
}
