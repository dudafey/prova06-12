import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { MeioPagamento } from "../models/meio-pagamento";
import { Produto } from "../models/produto";

@Injectable({
    providedIn: "root",
})
export class MeioPagamentoService {
    private baseUrl = "https://localhost:44302/api/meio-pagamento";

    constructor(private http: HttpClient) {}

    list(): Observable<MeioPagamento[]> {
        return this.http.get<MeioPagamento[]>(`${this.baseUrl}/list`);
    }
    
}