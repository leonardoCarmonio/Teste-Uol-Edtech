using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TesteUolEdtech.Domain.Interfaces.Services;
using TesteUolEdtech.Domain.Interfaces.UoW;
using TesteUolEdtech.Domain.Models;
using TesteUolEdtech.Services.API.ViewModels;

namespace TesteUolEdtech.Services.API.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class CursosController : ControllerBase
    {
        private readonly ICursoService _cursoService;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public CursosController(ICursoService cursoService, IMapper mapper, IUnitOfWork uow)
        {
            _cursoService = cursoService;
            _mapper = mapper;
            _uow = uow;
        }

        [HttpGet]
        public IEnumerable<CursoViewModel> Get()
        {
            return _mapper.Map<IEnumerable<CursoViewModel>>(_cursoService.ObterCursosCompleto());
        }

        [HttpGet]
        [Route("ObterPorPeriodoAcademico/{idPeriodoAcademicoOrigem:int}/{idPeriodoAcademicoDestino:int}")]
        public IEnumerable<CursoViewModel> ObterPorPeriodoAcademico(int idPeriodoAcademicoOrigem, int idPeriodoAcademicoDestino)
        {
            return _mapper.Map<IEnumerable<CursoViewModel>>(_cursoService.ObterCursosParaMigracaoDeTurmaPorPeriodoAcademico(idPeriodoAcademicoOrigem, idPeriodoAcademicoDestino));
        }

        [HttpPut]
        [Route("MigrarAlunosDeTurma")]
        public ActionResult MigrarAlunosDeTurma([FromBody] AlunoTurmaMigracaoViewModel alunoTurmaMigracaoViewModel)
        {
            var periodoAcademicoOrigem = _mapper.Map<PeriodoAcademico>(alunoTurmaMigracaoViewModel.PeriodoAcademicoOrigem);
            var periodoAcademicoDestino = _mapper.Map<PeriodoAcademico>(alunoTurmaMigracaoViewModel.PeriodoAcademicoDestino);
            var turmasMigracao = _mapper.Map<IEnumerable<Turma>>(alunoTurmaMigracaoViewModel.TurmasMigracao);

            _cursoService.MigrarAlunosDeTurma(periodoAcademicoOrigem, periodoAcademicoDestino, turmasMigracao);

            if(!_cursoService.ProcessamentoRealizadoComSucesso()) return BadRequest();            

            _uow.Commit();
            return Ok();
        }

    }
}