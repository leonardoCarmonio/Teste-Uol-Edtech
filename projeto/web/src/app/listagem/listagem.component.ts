import { Component, OnInit } from '@angular/core';
import { Observable, empty } from 'rxjs';
import { catchError } from 'rxjs/operators';

import { Curso } from '../model/curso';
import { CursosService } from '../cursos.service';
import { ModalAlertaService } from '../shared/modal-alerta.service';

@Component({
  selector: 'app-listagem',
  templateUrl: './listagem.component.html',
  styleUrls: ['./listagem.component.css']
})
export class ListagemComponent implements OnInit {

  public cursos$: Observable<Curso[]>;

  constructor(private cursoService: CursosService, private modalAlertaService: ModalAlertaService) { }

  ngOnInit() {
    this.obterCursos();
  }

   obterCursos(): void {
    this.cursos$ = this.cursoService.obterCursosCompletos()
    .pipe(
      catchError(error => {
        console.error(error);
        this.modalAlertaService.exibirAlertaDeErro('Erro ao obter alunos para migração');
        return empty();
      })
    );
  }

}
