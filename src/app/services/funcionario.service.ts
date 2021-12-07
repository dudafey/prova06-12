import { Funcionario } from "src/app/models/funcionario";
import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";

@Injectable({
    providedIn: "root",
})

export class FuncionarioService {
    private baseUrl = "https://localhost:44382/Funcionario";

    constructor(private http: HttpClient) {}

    create(funcionario: Funcionario): Observable<Funcionario> {
        return this.http.post<Funcionario>(`${this.baseUrl}`, funcionario);
    }

    getAll(): Observable<Funcionario[]> {
        return this.http.get<Funcionario[]>(`${this.baseUrl}`);
    }
}
