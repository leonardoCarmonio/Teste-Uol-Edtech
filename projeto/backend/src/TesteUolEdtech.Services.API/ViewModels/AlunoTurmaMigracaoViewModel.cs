using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TesteUolEdtech.Services.API.ViewModels
{
    public class AlunoTurmaMigracaoViewModel
    {
        public PeriodoAcademicoViewModel PeriodoAcademicoOrigem { get; set; }
        public PeriodoAcademicoViewModel PeriodoAcademicoDestino { get; set; }
        public IEnumerable<TurmaViewModel> TurmasMigracao { get; set; }
    }
}
