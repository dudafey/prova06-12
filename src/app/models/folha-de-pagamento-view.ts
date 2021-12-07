export interface FolhaDePagamento {
    id?: number;
    criadoEm?: Date;
    atualizadoEm?: Date;
    nome?: string;
    matricula?: number;
    mes: number;
    ano: number;
    salarioBruto: number;
    salarioLiquido: number;
    impostoRenda: number;
    inss: number;
    fgts: number;
}