import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { Funcionario } from "src/app/models/funcionario";
import { FuncionarioService } from "src/app/services/funcionario.service";

@Component({
    selector: "app-cadastrar-funcionario",
    templateUrl: "./cadastrar-funcionario.component.html",
    styleUrls: ["./cadastrar-funcionario.component.css"],
})
export class CadastrarFuncionarioComponent implements OnInit {

    nome!: string;
    email!: string;
    matricula!: number;

    constructor(
        private router: Router,
        private funcionarioService: FuncionarioService
    ) {}

    ngOnInit(): void { }

    cadastrar(): void {

        let funcionario: Funcionario = {
            nome: this.nome,
            email: this.email,
            matricula: this.matricula
        };

        this.funcionarioService.create(funcionario).subscribe((funcionario) => {
            console.log(funcionario);
            this.router.navigate(["produto/listar"]);
        });
    }
}
