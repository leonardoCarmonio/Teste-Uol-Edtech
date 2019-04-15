using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TesteUolEdtech.Services.API.ViewModels
{
    public class TurmaViewModel
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public IList<AlunoViewModel> Alunos { get; set; }
    }
}
