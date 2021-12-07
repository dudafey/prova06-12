import { Component, OnInit } from "@angular/core";
import { MeioPagamento } from "src/app/models/meio-pagamento";
import { Venda } from "src/app/models/venda";
import { MeioPagamentoService } from "src/app/services/meio-pagamento.service";
import { VendaService } from "src/app/services/venda.service";


@Component({
    selector: "app-cadastrar-venda",
    templateUrl: "./cadastrar-venda.component.html",
    styleUrls: ["./cadastrar-venda.component.css"],
})
export class CadastrarVendaComponent implements OnInit {
    nome!: string;
    mPagamentos!: MeioPagamento[];
    mPagamentoId!: number;

    constructor(
        private vendaService: VendaService,
        private meioPagamentoService: MeioPagamentoService
    ) {}

    ngOnInit(): void {
        this.meioPagamentoService.list().subscribe((mPagamentos) => {
           
            this.mPagamentos = mPagamentos;
            console.log("teste", this.mPagamentos)
        });
    }

    cadastrar(): void {
        let venda: Venda = {
            cliente: this.nome,
            meioPagamento: this.mPagamentoId
        };
        this.vendaService.create(venda).subscribe((resultado) => {
            console.log(resultado);
        });
    }
}