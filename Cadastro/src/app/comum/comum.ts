export class Comum{
  static trataErro(erro: any): void {
    throw new Error("Method not implemented.");
  }

    trataErro(erro: any){
        let mensagem = erro.status + " :" + erro.message;
        console.log(mensagem);
        alert(mensagem);
      }
}