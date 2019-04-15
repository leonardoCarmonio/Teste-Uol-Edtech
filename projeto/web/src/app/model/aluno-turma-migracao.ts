import { Turma } from './turma';
import { PeriodoAcademico } from './periodo-academico';

export interface AlunoTurmaMigracao {
    PeriodoAcademicoOrigem: PeriodoAcademico;
    PeriodoAcademicoDestino: PeriodoAcademico;
    TurmasMigracao: Turma[];
}
