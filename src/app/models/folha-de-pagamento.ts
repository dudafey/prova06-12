import { Funcionario } from "./funcionario";

export interface FolhaDePagamento {
    id?: number;
    criadoEm?: Date;
    atualizadoEm?: Date;
    horasTrabalhadas: number;
    valorHora: number;
    mes: number;
    ano: number;
    idFuncionario: number;
    funcionario?: Funcionario;
}