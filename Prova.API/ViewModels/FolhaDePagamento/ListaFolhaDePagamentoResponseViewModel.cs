using System;

namespace Prova.API.ViewModels.FolhaDePagamento {
    public class ListaFolhaDePagamentoResponseViewModel {

        public int Id { get; set; }
        public DateTime CriadoEm { get; set; }
        public DateTime AtualizadoEm { get; set; }
        public string Nome { get; set; }
        public decimal Matricula { get; set; }
        public int Ano { get; set; }
        public int Mes { get; set; }
        public decimal SalarioBruto { get; set; }
        public decimal SalarioLiquido { get; set; }
        public decimal ImpostoRenda { get; set; }
        public decimal Inss { get; set; }
        public decimal Fgts { get; set; }

    }
}
