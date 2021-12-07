using Prova.API.ViewModels.FolhaDePagamento;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Prova.API.Entities {

    public class FolhaDePagamento {

        [Key]
        public int Id { get; set; }
        public DateTime CriadoEm { get; set; }
        public DateTime AtualizadoEm { get; set; }
        public decimal HorasTrabalhadas { get; set; }
        public decimal ValorHora { get; set; }
        public int Ano { get; set; }
        public int Mes { get; set; }

        /* EF Relations */
        [ForeignKey("Funcionario"), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdFuncionario { get; set; }
        public Funcionario Funcionario { get; set; }

        public FolhaDePagamentoResponseViewModel ParseFolhaDePagamentoParaFolhaDePagamentoResponse() {
            return new FolhaDePagamentoResponseViewModel {
                Id = Id,
                CriadoEm = CriadoEm,
                AtualizadoEm = AtualizadoEm,
                IdFuncionario = IdFuncionario,
                HorasTrabalhadas = HorasTrabalhadas,
                ValorHora = ValorHora,
                Ano = Ano,
                Mes = Mes
            };
        }

        public ListaFolhaDePagamentoResponseViewModel ParseFolhaDePagamentoParaListaFolhaDePagamentoResponse(Funcionario funcionario) {

            var salarioBruto = HorasTrabalhadas * ValorHora;
            var impostoDeRenda = (decimal)((CalcularPercentualImpostoDeRenda(salarioBruto) / 100) * (double)salarioBruto);
            var inss = CalcularInss(salarioBruto);
            var fgts = (decimal)((double)8 / 100 * (double)salarioBruto);

            return new ListaFolhaDePagamentoResponseViewModel {
                Id = Id,
                CriadoEm = CriadoEm,
                AtualizadoEm = AtualizadoEm,
                Nome = funcionario.Nome,
                Matricula = funcionario.Matricula,
                Ano = Ano,
                Mes = Mes,
                SalarioBruto = salarioBruto,
                ImpostoRenda = (decimal)impostoDeRenda,
                Inss = inss,
                Fgts = fgts,
                SalarioLiquido = salarioBruto - impostoDeRenda - inss
            };
        }

        private static double CalcularPercentualImpostoDeRenda(decimal salarioBruto) {

            if(salarioBruto <= 1903.98m) {
                return 0;
            }
            else if(salarioBruto > 1903.98m && salarioBruto <= 2826.65m) {
                return 7.5d;
            } 
            else if(salarioBruto > 2826.65m && salarioBruto <= 3751.05m) {
                return 15d;
            } 
            else if(salarioBruto > 3751.05m && salarioBruto <= 4664.68m) {
                return 22.5d;
            } 
            else if(salarioBruto > 4664.68m) {
                return 27.5d;
            }

            return 0;
        }

        private static decimal CalcularInss(decimal salarioBruto) {

            if(salarioBruto <= 1659.38m) {
                return (decimal)((double)8 / 100 * (double)salarioBruto);
            } else if(salarioBruto > 1659.38m && salarioBruto <= 2765.66m) {
                return (decimal)((double)9 / 100 * (double)salarioBruto);
            } else if(salarioBruto > 2765.66m && salarioBruto <= 5531.31m) {
                return (decimal)((double)11 / 100 * (double)salarioBruto);
            } else if(salarioBruto > 5531.31m) {
                return 608.44m;
            }

            return 0;
        }
    }
}
