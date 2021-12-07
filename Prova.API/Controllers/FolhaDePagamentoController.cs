using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Prova.API.Entities;
using Prova.API.ViewModels.FolhaDePagamento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prova.API.Controllers {

    [ApiController]
    [Route("[controller]")]
    public class FolhaDePagamentoController : ControllerBase {

        private readonly Context _context;

        public FolhaDePagamentoController(Context context) {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> ListarFolhaDePagamento() {

            var response = new List<ListaFolhaDePagamentoResponseViewModel>();
            var folhas = await _context.Folhas.ToListAsync();

            folhas.ForEach(async x => {

                var funcionario = await _context.Funcionarios.FirstOrDefaultAsync(y => y.Id == x.IdFuncionario);
                var folhasResponse = x.ParseFolhaDePagamentoParaListaFolhaDePagamentoResponse(funcionario);
                response.Add(folhasResponse);
            });

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarFolhaDePagamento([FromBody] CadastrarFolhaDePagamentoViewModel cadastrarFolhaDePagamentoViewModel) {

            if(!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            if(!(await PodeCadastrarFolhaDePagamento(cadastrarFolhaDePagamentoViewModel.IdFuncionario, cadastrarFolhaDePagamentoViewModel.Mes, cadastrarFolhaDePagamentoViewModel.Ano))) {
                return BadRequest($"Ja existe uma folha de pagamento no mes {cadastrarFolhaDePagamentoViewModel.Mes} do ano {cadastrarFolhaDePagamentoViewModel.Ano} para o funcionario {cadastrarFolhaDePagamentoViewModel.IdFuncionario}");
            }

            var folhaParaInserir = new FolhaDePagamento {
                CriadoEm = DateTime.Now,
                AtualizadoEm = DateTime.Now,
                IdFuncionario = cadastrarFolhaDePagamentoViewModel.IdFuncionario,
                HorasTrabalhadas = cadastrarFolhaDePagamentoViewModel.HorasTrabalhadas,
                ValorHora = cadastrarFolhaDePagamentoViewModel.ValorHora,
                Mes = cadastrarFolhaDePagamentoViewModel.Mes,
                Ano = cadastrarFolhaDePagamentoViewModel.Ano
            };

            await _context.AddAsync(folhaParaInserir);
            await _context.SaveChangesAsync();

            var response = folhaParaInserir.ParseFolhaDePagamentoParaFolhaDePagamentoResponse();

            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> ExcluirFolhaDePagamento([FromQuery] int id) {

            var folhaParaExclusao = await _context.Folhas.FirstOrDefaultAsync(x => x.Id == id);

            _context.Remove(folhaParaExclusao);
            await _context.SaveChangesAsync();

            return Ok();
        }

        private async Task<bool> PodeCadastrarFolhaDePagamento(int idFuncionario, int mes, int ano) {

            var folhasDoFuncionario = await _context.Folhas.Where(x => x.IdFuncionario == idFuncionario && x.Mes == mes && x.Ano == ano).FirstOrDefaultAsync();

            return (folhasDoFuncionario == null);
        }

    }
}
