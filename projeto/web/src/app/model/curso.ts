import { Turma } from './turma';

export interface Curso {
    id: number;
    descricao: string;
    turmas: Turma[];
}