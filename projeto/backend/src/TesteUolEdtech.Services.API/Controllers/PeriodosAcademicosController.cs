using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TesteUolEdtech.Domain.Interfaces.Services;
using TesteUolEdtech.Services.API.ViewModels;

namespace TesteUolEdtech.Services.API.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class PeriodosAcademicosController : ControllerBase
    {
        private readonly IPeriodoAcademicoService _periodoAcademicoService;
        private readonly IMapper _mapper;

        public PeriodosAcademicosController(IPeriodoAcademicoService periodoAcademicoService, IMapper mapper)
        {
            _periodoAcademicoService = periodoAcademicoService;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<PeriodoAcademicoViewModel> Get()
        {
            return _mapper.Map<IEnumerable<PeriodoAcademicoViewModel>>(_periodoAcademicoService.ObterTodos());
        }
    }
}