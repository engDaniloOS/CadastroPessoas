import { BaseModel } from './base.model';
import { Contato } from './contato.model';
import { Endereco } from './endereco.model copy 3';

export class Pessoa extends BaseModel{
    Nome: string;
    CPF: string;
    DataNascimento: Date;
    ContatoId: number;
    Contato: Contato;
    EnderecoId: number;
    Endereco: Endereco;
}
