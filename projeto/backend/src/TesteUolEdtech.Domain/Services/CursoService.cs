using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TesteUolEdtech.Domain.Interfaces.Repository;
using TesteUolEdtech.Domain.Interfaces.Services;
using TesteUolEdtech.Domain.Models;
using TesteUolEdtech.Domain.Validations;
using static TesteUolEdtech.Domain.Models.AlunoTurma;

namespace TesteUolEdtech.Domain.Services
{
    public class CursoService : BaseService, ICursoService
    {
        private readonly ICursoRepository _cursoRepository;
        private readonly IPeriodoAcademicoRepository _periodoAcademicoRepository;
        private readonly IAlunoTurmaRepository _alunoTurmaRepository;
        private readonly ITurmaRepository _turmaRepository;

        public CursoService(ICursoRepository cursoRepository, IPeriodoAcademicoRepository periodoAcademicoRepository, 
                            IAlunoTurmaRepository alunoTurmaRepository, ITurmaRepository turmaRepository)
        {
            _cursoRepository = cursoRepository;
            _periodoAcademicoRepository = periodoAcademicoRepository;
            _alunoTurmaRepository = alunoTurmaRepository;
            _turmaRepository = turmaRepository;
        }

        public IEnumerable<Curso> ObterCursosCompleto()
        {
            return _cursoRepository.ObterCursosCompleto();
        }

        public IEnumerable<Curso> ObterCursosParaMigracaoDeTurmaPorPeriodoAcademico(int idPeriodoAcademicoOrigem, int idPeriodoAcademicoDestino)
        {
            return _cursoRepository.ObterCursosParaMigracaoDeTurmaPorPeriodoAcademico(idPeriodoAcademicoOrigem, idPeriodoAcademicoDestino);
        }

        public void MigrarAlunosDeTurma(PeriodoAcademico periodoAcademico, PeriodoAcademico periodoAcademicoMigracao, IEnumerable<Turma> turmasMigracao)
        {
            var periodoAcademicoOrigem = _periodoAcademicoRepository.ObterPorId(periodoAcademico.Id);
            var periodoAcademicoDestino = _periodoAcademicoRepository.ObterPorId(periodoAcademicoMigracao.Id);

            periodoAcademicoOrigem.ValidationResult = new PeriodoAcademicoDeveEstarAptoParaTrocaValidation(periodoAcademicoDestino).Validate(periodoAcademicoOrigem);
            AdicionarResultadoProcessamento(periodoAcademico.ValidationResult);

            if (!periodoAcademicoOrigem.ValidationResult.IsValid) return;

            foreach (var turma in turmasMigracao)
            {
                var turmaMigracao = _turmaRepository.ObterTurmaParaMigracao(periodoAcademicoOrigem.Id, periodoAcademicoDestino.Id, turma.Id);

                if (turmaMigracao == null)
                {
                    AdicionarResultadoProcessamento(new FluentValidation.Results.ValidationResult(
                            new List<ValidationFailure>() { new ValidationFailure("turma", "Nenhuma turma encontrada para realizar a migração") }
                        )
                    );
                    return;
                }

                foreach (var alunoTurma in turma.AlunosTurma)
                {
                    var alunoTurmaMigrado = _alunoTurmaRepository.Buscar(a => a.TurmaId == turma.Id && a.AlunoId == alunoTurma.AlunoId).FirstOrDefault();

                    if (alunoTurmaMigrado == null)
                    {
                        AdicionarResultadoProcessamento(new FluentValidation.Results.ValidationResult(
                                new List<ValidationFailure>() { new ValidationFailure("aluno", "Nenhuma turma encontrada para o aluno realizar a migração") }
                            )
                        );
                        return;
                    }

                    alunoTurmaMigrado.AlterarParaMigrado();
                    _alunoTurmaRepository.Atualizar(alunoTurmaMigrado);

                    _alunoTurmaRepository.Adicionar(AlunoTurmaFactory.NovoAlunoTurmaCompleto(alunoTurma.AlunoId, turmaMigracao.Id, turma.Id));
                }
            }
        }

        public void Dispose()
        {
            _cursoRepository.Dispose();
            _periodoAcademicoRepository.Dispose();
            _alunoTurmaRepository.Dispose();
            _turmaRepository.Dispose();
        }
    }
}
