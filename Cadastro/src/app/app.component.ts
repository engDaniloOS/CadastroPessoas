import { Component, Inject, OnInit } from '@angular/core';
import { Http } from '@angular/http';
import { Pessoa } from './dominio/pessoa.model';
import { Router } from '@angular/router';
import { Comum } from './comum/comum';
import { stringify } from '@angular/core/src/util';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent implements OnInit{

  //#region campos
  title = 'Cadastro';
  urlApi = 'http://localhost:5000/api/pessoa';
  dataFromApi: Array<Pessoa> = [];
  listaArmazenada: Array<any> = [];
  filtro: string = "";
  //#endregion

  //#region construtor
  constructor(@Inject(Http) private http: Http, @Inject(Router) private router: Router){
    router.events.subscribe(() =>this.doListar());
  }
  //#endregion

  //#region funções
  ngOnInit(){
    this.doListar();
  }

  doFiltro(){
    if (this.filtro)
      this.dataFromApi = this.listaArmazenada.filter(
                              p => p.nome.toLocaleLowerCase().includes(this.filtro.toLocaleLowerCase()));

    else
      this.dataFromApi = this.listaArmazenada;
  }

  hasData(){
    return this.dataFromApi.length > 0;
  }

  doLimpar(){
    this.dataFromApi = new Array<Pessoa>();
  }

  doExcluir(id : number){
    this.http.delete(this.urlApi+'/'+id).subscribe(

      sucesso => { alert('Exclusão realizada com sucesso!')
                   this.doListar(); },

      erro => Comum.trataErro(erro)

    );  
  }

  doListar(){

    this.http.get(this.urlApi).subscribe(

      resposta => { this.doLimpar();
                    const apiResultado = resposta.json();
                    apiResultado.forEach(item => {
                    this.dataFromApi.push(item); })
                    this.listaArmazenada = this.dataFromApi; },

      erro => Comum.trataErro(erro)

    );
  }
  //#endregion
}
