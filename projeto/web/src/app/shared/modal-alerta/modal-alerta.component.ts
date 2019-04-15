import { Component, OnInit, Input } from '@angular/core';
import { BsModalRef } from 'ngx-bootstrap/modal';

@Component({
  selector: 'app-modal-alerta',
  templateUrl: './modal-alerta.component.html',
  styleUrls: ['./modal-alerta.component.css']
})
export class ModalAlertaComponent implements OnInit {

  @Input() tipo = 'success';
  @Input() mensagem: string;

  constructor(public bsModalRef: BsModalRef) { }

  ngOnInit() {
  }

  public fechar(): void {
    this.bsModalRef.hide();
  }

}
