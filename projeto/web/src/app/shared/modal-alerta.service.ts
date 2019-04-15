import { Injectable } from '@angular/core';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { ModalAlertaComponent } from './modal-alerta/modal-alerta.component';

export enum TiposAlerta {
  ERRO = 'danger',
  SUCESSO = 'success'
}

@Injectable({
  providedIn: 'root'
})
export class ModalAlertaService {

  constructor(private modalService: BsModalService) { }

  public exibirAlerta(mensagem: string, tipo: string, tempoParaFechar?: number): void {
    const bsModalRef: BsModalRef = this.modalService.show(ModalAlertaComponent);
    bsModalRef.content.tipo = tipo;
    bsModalRef.content.mensagem = mensagem;

    if (tempoParaFechar) {
      setTimeout(() => bsModalRef.hide(), tempoParaFechar);
    }
  }

  public exibirAlertaDeErro(message: string): void {
    this.exibirAlerta(message, TiposAlerta.ERRO);
  }

  public exibirAlertaDeSucesso(message: string): void {
    this.exibirAlerta(message, TiposAlerta.SUCESSO, 3000);
  }
}
