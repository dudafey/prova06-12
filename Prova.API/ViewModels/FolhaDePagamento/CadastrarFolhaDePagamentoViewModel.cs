using System;
using System.ComponentModel.DataAnnotations;

namespace Prova.API.ViewModels.FolhaDePagamento {
    public class CadastrarFolhaDePagamentoViewModel {

        [Required(ErrorMessage = "O campo IdFuncionario é Obrigatorio")]
        public int IdFuncionario { get; set; }

        [Required(ErrorMessage = "O campo HorasTrabalhadas é Obrigatorio")]
        public decimal HorasTrabalhadas { get; set; }

        [Required(ErrorMessage = "O campo ValorHora é Obrigatorio")]
        public decimal ValorHora { get; set; }

        [Required(ErrorMessage = "O campo Ano é Obrigatorio")]
        [Range(2000, 3000, ErrorMessage = "O ano está invalido")]
        public int Ano { get; set; }

        [Required(ErrorMessage = "O campo Mes é Obrigatorio")]
        [Range(1, 12, ErrorMessage = "O mês está invalido")]
        public int Mes { get; set; }

    }
}
