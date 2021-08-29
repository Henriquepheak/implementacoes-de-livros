import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TipoServicosListagemPage } from './tipo-servicos-listagem.page';

const routes: Routes = [
  {
    path: '',
    component: TipoServicosListagemPage
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class TipoServicosListagemPageRoutingModule { }
