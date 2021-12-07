using Prova.API.ViewModels.Funcionario;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Prova.API.Entities {
    public class Funcionario {

        [Key]
        public int Id { get; set; }
        public DateTime CriadoEm { get; set; }
        public DateTime AtualizadoEm { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public decimal Matricula { get; set; }

        /* EF Relations */
        public virtual List<FolhaDePagamento> Folhas { get; set; }

        public FuncionarioResponseViewModel ParseFuncionarioParaFuncionarioResponse() {
            return new FuncionarioResponseViewModel {
                Id = Id,
                CriadoEm = CriadoEm,
                AtualizadoEm = AtualizadoEm,
                Nome = Nome,
                Email = Email,
                Matricula = Matricula
            };
        }
    }
}
