using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TesteUolEdtech.Services.API.ViewModels
{
    public class PeriodoAcademicoViewModel
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public DateTime? Inicio { get; set; }
        public DateTime? Fim { get; set; }
    }
}
