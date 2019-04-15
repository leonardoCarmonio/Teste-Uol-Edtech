import { Turma } from './../model/turma';
import { Component, OnInit } from '@angular/core';
import { take, map, tap, catchError } from 'rxjs/operators';
import { FormGroup, FormBuilder, FormArray, FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';

import { PeriodoAcademico } from './../model/periodo-academico';
import { CursosService } from '../cursos.service';
import { Curso } from '../model/curso';
import { Aluno } from '../model/aluno';
import { ModalAlertaService } from '../shared/modal-alerta.service';
import { empty } from 'rxjs';

@Component({
  selector: 'app-migracao',
  templateUrl: './migracao.component.html',
  styleUrls: ['./migracao.component.css']
})
export class MigracaoComponent implements OnInit {

  public periodosAcademicos: PeriodoAcademico[] = [];
  public periodosAcademicosDestino: PeriodoAcademico[] = [];
  public cursos: Curso[] = [];
  public formulario: FormGroup;

  constructor(private cursoService: CursosService,
    private formBuilder: FormBuilder,
    private router: Router,
    private modalAlertaService: ModalAlertaService) { }

  ngOnInit() {
    this.iniciarFormulario();
    this.obterPeriodosAcademicos();

    this.formulario.get('periodoAcademicoOrigem').valueChanges
      .pipe(
        map((periodoAcademicoOrigem: PeriodoAcademico) => this.obterPeriodosAcademicosDestino(periodoAcademicoOrigem))
      ).subscribe();

    this.formulario.get('periodoAcademicoDestino').valueChanges
      .pipe(
        map((periodoAcademicoDestino: PeriodoAcademico) => this.obterAlunosParaMigracao(periodoAcademicoDestino))
      ).subscribe();
  }

  public iniciarFormulario(): void {
    this.formulario = this.formBuilder.group({
      periodoAcademicoOrigem: [null, Validators.required],
      periodoAcademicoDestino: [null, Validators.required],
      turmasMigracao: [null]
    });
  }

  public obterPeriodosAcademicos(): void {
    this.cursoService.obterPeriodosAcademicos()
      .pipe(
        catchError(error => {
          console.error(error);
          this.modalAlertaService.exibirAlertaDeErro('Erro ao obter períodos acadêmicos!');
          return empty();
        }),
        take(1)
      )
      .subscribe((dados: PeriodoAcademico[]) => this.periodosAcademicos = dados);
  }

  public obterPeriodosAcademicosDestino(periodoAcademicoOrigem: PeriodoAcademico): void {
    this.formulario.patchValue({periodoAcademicoDestino: null});
    this.periodosAcademicosDestino = [];
    this.cursos = [];

    if (periodoAcademicoOrigem !== null) {
      const ultimoNumeroPeriodoAcademicoSelecionado = Number(periodoAcademicoOrigem.descricao.slice(-1));

      this.periodosAcademicosDestino = this.periodosAcademicos.filter( ( item, index, array ) => {
          const ultimoNumeroItemArray = Number(item.descricao.slice(-1));
          return (
                    periodoAcademicoOrigem.id !== item.id &&
                    (
                      (ultimoNumeroPeriodoAcademicoSelecionado % 2 === 0 && ultimoNumeroItemArray % 2 === 0) ||
                      (ultimoNumeroPeriodoAcademicoSelecionado % 2 > 0 && ultimoNumeroItemArray % 2 > 0)
                    )
                  );
      });
    }
  }

  public obterAlunosParaMigracao(periodoAcademicoDestino: PeriodoAcademico) {
    this.cursos = [];
    const periodoAcademicoOrigem: PeriodoAcademico = this.formulario.get('periodoAcademicoOrigem').value;

    if (periodoAcademicoOrigem !== null && periodoAcademicoDestino !== null) {
      this.cursoService.obterAlunosParaMigracao(periodoAcademicoOrigem.id, periodoAcademicoDestino.id)
      .pipe(
        catchError(error => {
          console.error(error);
          this.modalAlertaService.exibirAlertaDeErro('Erro ao obter alunos para migração');
          return empty();
        }),
        take(1)
      )
      .subscribe((dados: Curso[]) => {
        if (dados.length === 0) {
          this.modalAlertaService.exibirAlertaDeErro('Nenhum aluno encontrado para migração!');
        }
        this.cursos = dados;
      });
    }
  }

  public enviar(): void {

    const turmas = this.tratarTurmasMigracaoEnvio();
    const dadosEnvio = Object.assign({}, this.formulario.value);
    Object.assign(dadosEnvio, { turmasMigracao: turmas});

    if (this.formulario.valid && turmas.length > 0) {
      this.cursoService.migrarAlunosDeTurma(dadosEnvio)
      .pipe(take(1))
      .subscribe(
        success => {
          this.router.navigate(['/migracao-mensagem']);
        },
        error => {
          this.modalAlertaService.exibirAlertaDeErro('Erro ao migrar alunos');
        }
      );
    } else {
      this.modalAlertaService.exibirAlertaDeErro('Preencha todos os campos e selecione ao menos um aluno!');
    }
  }

  public tratarTurmasMigracaoEnvio(): Turma[] {
    const turmasMigracao: Turma[] = [];
    for (const curso of this.cursos) {
      for (const turma of curso.turmas) {
        const turmaEnvio: Turma = { id: turma.id, descricao: turma.descricao, alunos: turma.alunos.filter((item) => item.selecionado)};
        if (turmaEnvio.alunos.length > 0) {
            turmasMigracao.push(turmaEnvio);
        }
      }
    }
    return turmasMigracao;
  }

}
