export interface MeioPagamento {
    MeioPagamentoId?: number;
    Estornavel: boolean;
    MetodoDePagamento: string;
    criadoEm?: Date;
}