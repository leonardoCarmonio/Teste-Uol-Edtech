import { Injectable } from '@angular/core';
import { environment } from '../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { take } from 'rxjs/operators';

import { PeriodoAcademico } from './model/periodo-academico';
import { Curso } from './model/curso';
import { AlunoTurmaMigracao } from './model/aluno-turma-migracao';

@Injectable({
  providedIn: 'root'
})
export class CursosService {

  private readonly API = `${environment.API}`;

  constructor(private http: HttpClient) { }

  public obterCursosCompletos(): Observable<Curso[]> {
    return this.http.get<Curso[]>(`${this.API}cursos`);
  }

  public obterPeriodosAcademicos(): Observable<PeriodoAcademico[]> {
    return this.http.get<PeriodoAcademico[]>(`${this.API}periodosAcademicos`);
  }

  public obterAlunosParaMigracao(idPeriodoAcademicoOrigem: number, idPeriodoAcademicoDestino: number): Observable<Curso[]> {
    return this.http.get<Curso[]>(`${this.API}cursos/ObterPorPeriodoAcademico/${idPeriodoAcademicoOrigem}/${idPeriodoAcademicoDestino}`);
  }

  public migrarAlunosDeTurma(alunoTurmaMigracao: AlunoTurmaMigracao) {
    return this.http.put(`${this.API}cursos/MigrarAlunosDeTurma`, alunoTurmaMigracao).pipe(take(1));
  }

}
