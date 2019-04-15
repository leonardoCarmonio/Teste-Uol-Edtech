using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TesteUolEdtech.Services.API.ViewModels
{
    public class CursoViewModel
    {
        public int Id { get; set; }
        public string Descricao { get; set; }

        public IEnumerable<TurmaViewModel> Turmas { get; set; }

        public CursoViewModel()
        {
            Turmas = new List<TurmaViewModel>();
        }
    }
}
