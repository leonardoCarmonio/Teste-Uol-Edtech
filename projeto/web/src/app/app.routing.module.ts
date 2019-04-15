import { MensagemMigracaoComponent } from './migracao/mensagem-migracao/mensagem-migracao.component';

import { Routes, RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';

import { MigracaoComponent } from './migracao/migracao.component';
import { ListagemComponent } from './listagem/listagem.component';
import { HomeComponent } from './home/home.component';


const appRoutes: Routes = [
    { path: 'listagem', component: ListagemComponent },
    { path: 'migracao', component: MigracaoComponent },
    { path: 'migracao-mensagem', component: MensagemMigracaoComponent },
    { path: '', component: HomeComponent }
];

@NgModule({
    imports: [RouterModule.forRoot(appRoutes)],
    exports: [RouterModule]
})
export class AppRoutingModule {}
