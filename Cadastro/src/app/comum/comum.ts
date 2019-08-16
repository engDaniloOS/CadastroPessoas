export class Comum{
  static trataErro(erro: any): void {
    let mensagem = erro.status + " :" + erro._body;
        console.log(erro);
        alert(mensagem);
  }
}