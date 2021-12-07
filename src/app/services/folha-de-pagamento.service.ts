import { FolhaDePagamento } from "src/app/models/folha-de-pagamento";
import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";

@Injectable({
    providedIn: "root",
})

export class FolhaDePagamentoService {
    private baseUrl = "https://localhost:44382/FolhaDePagamento";

    constructor(private http: HttpClient) {}

    create(folha: FolhaDePagamento): Observable<FolhaDePagamento> {
        return this.http.post<FolhaDePagamento>(`${this.baseUrl}`, folha);
    }

    getAll(): Observable<FolhaDePagamento[]> {
        return this.http.get<FolhaDePagamento[]>(`${this.baseUrl}`);
    }

    delete(id: number): Observable<void> {
        return this.http.delete<void>(`${this.baseUrl}/$${id}`);
    }
}
