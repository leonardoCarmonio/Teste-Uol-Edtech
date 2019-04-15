import { Aluno } from './aluno';

export interface Turma {
    id: number;
    descricao: string;
    alunos: Aluno[];
}
