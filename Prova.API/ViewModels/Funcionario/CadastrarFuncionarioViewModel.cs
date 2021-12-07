using System.ComponentModel.DataAnnotations;

namespace Prova.API.ViewModels.Funcionario {
    public class CadastrarFuncionarioViewModel {

        [Required(ErrorMessage = "O campo Nome é Obrigatorio")]
        [MaxLength(100, ErrorMessage = "O Campo nome nao pode ter mais de 100 Caracteres")]
        [MinLength(3, ErrorMessage = "O Campo nome nao pode ter mais de 100 Caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo Email é Obrigatorio")]
        [RegularExpression("^(([^<>()[\\]\\.,;:\\s@\"]+(\\.[^<>()[\\]\\.,;:\\s@\"]+)*)|(\".+\"))@(([^<>()[\\]\\.,;:\\s@\"]+\\.)+[^<>()[\\]\\.,;:\\s@\"]{2,})$", ErrorMessage = "O Email é invalido")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "O campo Matricula é Obrigatorio")]
        public decimal Matricula { get; set; }

    }
}
