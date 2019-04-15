using System;
using System.Collections.Generic;
using System.Text;
using TesteUolEdtech.Domain.Interfaces.Repository;
using TesteUolEdtech.Domain.Interfaces.Services;
using TesteUolEdtech.Domain.Models;

namespace TesteUolEdtech.Domain.Services
{
    public class PeriodoAcademicoService : BaseService, IPeriodoAcademicoService
    {
        private readonly IPeriodoAcademicoRepository _periodoAcademicoRepository;
        public PeriodoAcademicoService(IPeriodoAcademicoRepository periodoAcademicoRepository)
        {
            _periodoAcademicoRepository = periodoAcademicoRepository;
        }

        public IEnumerable<PeriodoAcademico> ObterTodos()
        {
            return _periodoAcademicoRepository.ObterTodos();
        }

        public void Dispose()
        {
            _periodoAcademicoRepository.Dispose();
        }
    }
}
