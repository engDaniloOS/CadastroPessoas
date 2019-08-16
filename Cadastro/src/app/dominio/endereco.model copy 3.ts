import { BaseModel } from './base.model';

export class Endereco extends BaseModel{
    Numero: number;
    CEP: string;
    Logradouro: string;
    Complemento: string;
    Bairro: string;
    Cidade: string;
    Estado: string;
    Pais: string;
}