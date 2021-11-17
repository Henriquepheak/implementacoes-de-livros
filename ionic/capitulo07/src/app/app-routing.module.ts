import { NgModule } from '@angular/core';
import { PreloadAllModules, RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: '',
    redirectTo: 'dashboard',
    pathMatch: 'full'
  },
  {
    path: 'ordensdeservico-listagem',
    loadChildren: () => import('./pages/ordensdeservico/ordensdeservico-listagem/ordensdeservico-listagem.module').then(m => m.OrdensdeservicoListagemPageModule)
  },
  {
    path: 'dashboard',
    loadChildren: () => import('./pages/dashboard/dashboard.module').then(m => m.DashboardPageModule)
  },
  {
    path: 'ordensdeservico-add-edit/:id',
    loadChildren: () => import('./pages/ordensdeservico/ordensdeservico-add-edit/ordensdeservico-add-edit.module').then(m => m.OrdensdeservicoAddEditPageModule)
  },
  {
    path: 'clientes-add-edit.page',
    loadChildren: () => import('./pages/clientes/clientes-add-edit/clientes-add-edit.module').then(m => m.ClientesAddEditPageModule)
  },
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes, { preloadingStrategy: PreloadAllModules })
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
