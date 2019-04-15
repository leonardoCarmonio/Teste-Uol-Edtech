using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteUolEdtech.Domain.Models;
using TesteUolEdtech.Services.API.ViewModels;

namespace TesteUolEdtech.Services.API.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Curso, CursoViewModel>();
            CreateMap<Turma, TurmaViewModel>()
                 .ForMember(turmaViewModel => turmaViewModel.Alunos, a => a.MapFrom(turma => turma.AlunosTurma.Select(alunoTurma => alunoTurma.Aluno).ToList()));
            CreateMap<Aluno, AlunoViewModel>();
            CreateMap<PeriodoAcademico, PeriodoAcademicoViewModel>();
        }
    }
}
