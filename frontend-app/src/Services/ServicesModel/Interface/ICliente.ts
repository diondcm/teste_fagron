
export interface IClientes
{
    id : number;
    nome: string;
    sobrenome: string;
    //Deve validar o cpf, deve ter mascara
    cpf: string;
    dataNasc: Date;    
    idade: number;
    profissao: number;
}