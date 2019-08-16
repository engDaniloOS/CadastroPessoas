import { Component, OnInit, Inject } from '@angular/core';
import { Pessoa } from '../dominio/pessoa.model';
import { Contato } from '../dominio/contato.model';
import { Endereco } from '../dominio/endereco.model copy 3';
import { Router } from '@angular/router';
import { Http } from '@angular/http';
import { Comum } from '../comum/comum';

@Component({
  selector: 'app-adicionar',
  templateUrl: './adicionar.component.html',
  styleUrls: ['./adicionar.component.css']
})

export class AdicionarComponent{

  //#region  campos
  title = 'Cadastrar';
  apiUrl= "http://localhost:5000/api/pessoa";
  msgSucesso = 'Usuário cadastrado com sucesso!'
  pessoa: Pessoa = new Pessoa();
  contato: Contato = new Contato();
  endereco: Endereco = new Endereco();
  //#endregion

  //#region construtor
  constructor(@Inject(Http) private http: Http,
              @Inject(Router) private router: Router) { 
    this.pessoa = new Pessoa();
  }
  //#endregion

  //#region funções
  doCadastrar(){
    this.pessoa.Contato = this.contato;
    this.pessoa.Endereco = this.endereco;

    this.http.post(this.apiUrl, this.pessoa).subscribe(

      resposta => { const apiResultado = resposta.json();
                    this.pessoa = apiResultado;
                    alert(this.msgSucesso); },
      
      erro => Comum.trataErro(erro)

    );
      
    this.router.navigate(['/']);
  }
  //#endregion
}
