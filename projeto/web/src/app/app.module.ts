import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';
import { ModalModule } from 'ngx-bootstrap/modal';

import { AppComponent } from './app.component';
import { MigracaoComponent } from './migracao/migracao.component';
import { AppRoutingModule } from './app.routing.module';
import { ListagemComponent } from './listagem/listagem.component';
import { HomeComponent } from './home/home.component';
import { MensagemMigracaoComponent } from './migracao/mensagem-migracao/mensagem-migracao.component';
import { SharedModule } from './shared/shared.module';

@NgModule({
  declarations: [
    AppComponent,
    MigracaoComponent,
    ListagemComponent,
    HomeComponent,
    MensagemMigracaoComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
    ModalModule.forRoot(),
    SharedModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
