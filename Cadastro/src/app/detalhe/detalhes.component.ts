import { Component, OnInit, Inject } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Http } from '@angular/http';
import { Pessoa } from '../dominio/pessoa.model';
import { Comum } from '../comum/comum';

@Component({
  selector: 'app-detalhes',
  templateUrl: './detalhes.component.html',
  styleUrls: ['./detalhes.component.css']
})

export class DetalhesComponent implements OnInit {

  //#region campos
  title = "Detalhes";
  editado = 'Voltar';
  urlApi = 'http://localhost:5000/api/pessoa/';
  msgSucesso = 'Alterações realizadas com sucesso!';
  id: number;
  pessoa: Pessoa;
  //#endregion
  
  //#region construtor
  constructor(@Inject(ActivatedRoute) private route: ActivatedRoute,
              @Inject(Http) private http: Http,
              @Inject(Router) private router: Router) { 
    this.pessoa = new Pessoa();
  }
  //#endregion

  //#region funções
  ngOnInit() {
    this.route.params.subscribe(params => { this.id = +params['id']; });
    this.buscaPessoa(this.id);
  }

  buscaPessoa(id: number){
    this.http.get(this.urlApi+id).subscribe(

      resposta => { const apiResultado = resposta.json();
                    this.pessoa = apiResultado; },
      
      erro => Comum.trataErro(erro)

    );
  }

  doEditar(){
    const url = this.urlApi;
    this.http.put(url, this.pessoa).subscribe(

      resposta => { const apiResultado = resposta.json();
                    this.pessoa = apiResultado;
                    alert(this.msgSucesso); },
      
      erro => Comum.trataErro(erro)

    );
   
    this.router.navigate(['/']);
  }
  //#endregion
}



