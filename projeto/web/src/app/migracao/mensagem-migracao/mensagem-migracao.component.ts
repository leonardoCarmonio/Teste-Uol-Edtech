import { Component, OnInit } from '@angular/core';
import { Location } from '@angular/common';

@Component({
  selector: 'app-mensagem-migracao',
  templateUrl: './mensagem-migracao.component.html',
  styleUrls: ['./mensagem-migracao.component.css']
})
export class MensagemMigracaoComponent implements OnInit {

  constructor(private location: Location) { }

  ngOnInit() {
  }

  public voltar(): void {
    this.location.back();
  }

}
