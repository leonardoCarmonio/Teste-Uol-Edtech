import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ModalAlertaComponent } from './modal-alerta/modal-alerta.component';

@NgModule({
  declarations: [ModalAlertaComponent],
  imports: [
    CommonModule
  ],
  exports: [
    ModalAlertaComponent
  ],
  entryComponents: [ModalAlertaComponent]
})
export class SharedModule { }
// entryComponents: Informa os componentes que serão utilizados em tempo  de execução
