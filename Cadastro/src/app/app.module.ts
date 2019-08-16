import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpModule } from '@angular/http';
import { AppComponent } from './app.component';
import { RouterModule, Routes } from '@angular/router'
import { FormsModule } from '@angular/forms';
import { DetalhesComponent } from './detalhe/detalhes.component';

import { AppRoutingModule } from './app-routing.module';
import { AdicionarComponent } from './adicionar/adicionar.component';

const appRoutes : Routes = [
  { path: 'detalhes/:id', component: DetalhesComponent},
  { path: 'criar', component: AdicionarComponent},
];

@NgModule({
  declarations: [
    AppComponent,
    DetalhesComponent,
    AdicionarComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpModule,
    FormsModule,
    RouterModule.forRoot(appRoutes)
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
