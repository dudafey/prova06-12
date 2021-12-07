import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { Funcionario } from "src/app/models/funcionario";
import { FolhaDePagamento } from "src/app/models/folha-de-pagamento";
import { FuncionarioService } from "src/app/services/funcionario.service";
import { FolhaDePagamentoService } from "src/app/services/folha-de-pagamento.service";

@Component({
    selector: "app-cadastrar-folha-de-pagamento",
    templateUrl: "./cadastrar-folha-de-pagamento.component.html",
    styleUrls: ["./cadastrar-folha-de-pagamento.component.css"],
})
export class CadastrarFolhaDePagamentoComponent implements OnInit {

    horasTrabalhadas!: number;
    valorHora!: number;
    ano!: number;
    mes!: number;
    funcionarios!: Funcionario[];
    idFuncionario!: number;

    constructor(
        private router: Router,
        private folhaDePagamentoService: FolhaDePagamentoService,
        private funcionarioService: FuncionarioService
    ) {}

    ngOnInit(): void {
        this.funcionarioService.getAll().subscribe((funcionarios) => {
            this.funcionarios = funcionarios;
        });
    }

    cadastrar(): void {
        let folha: FolhaDePagamento = {
            horasTrabalhadas: this.horasTrabalhadas,
            valorHora: this.valorHora,
            ano: this.ano,
            mes: this.mes,
            idFuncionario: this.idFuncionario
        };

        this.folhaDePagamentoService.create(folha).subscribe((folha) => {
            console.log(folha);
            this.router.navigate(["produto/listar"]);
        });
    }
}
