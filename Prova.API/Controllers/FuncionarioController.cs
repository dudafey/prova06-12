using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Prova.API.Entities;
using Prova.API.ViewModels.Funcionario;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Prova.API.Controllers {

    [ApiController]
    [Route("[controller]")]
    public class FuncionarioController : ControllerBase {

        private readonly Context _context;

        public FuncionarioController(Context context) {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllFuncionarios() {

            var response = new List<FuncionarioResponseViewModel>();

            var allFuncionarios = await _context.Funcionarios.ToListAsync();
            allFuncionarios.ForEach(x => {
                var respViewModel = x.ParseFuncionarioParaFuncionarioResponse();
                response.Add(respViewModel);
            });

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarFuncionario(CadastrarFuncionarioViewModel cadastrarFuncionarioViewModel) {

            if(!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            var funcionarioParaInserir = new Funcionario {
                CriadoEm = DateTime.Now,
                AtualizadoEm = DateTime.Now,
                Nome = cadastrarFuncionarioViewModel.Nome,
                Email = cadastrarFuncionarioViewModel.Email,
                Matricula = cadastrarFuncionarioViewModel.Matricula
            };

            await _context.AddAsync(funcionarioParaInserir);
            await _context.SaveChangesAsync();

            var response = funcionarioParaInserir.ParseFuncionarioParaFuncionarioResponse();

            return Ok(response);
        }
    }
}
