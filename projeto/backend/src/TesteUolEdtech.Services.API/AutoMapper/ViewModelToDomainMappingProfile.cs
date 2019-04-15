using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteUolEdtech.Domain.Models;
using TesteUolEdtech.Services.API.ViewModels;
using static TesteUolEdtech.Domain.Models.Aluno;
using static TesteUolEdtech.Domain.Models.AlunoTurma;

namespace TesteUolEdtech.Services.API.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<CursoViewModel, Curso>();
            CreateMap<TurmaViewModel, Turma>()
                .ForMember(turma => turma.AlunosTurma, a => a.MapFrom(turmaViewModel => 
                    turmaViewModel.Alunos.Select(
                        aluno => AlunoTurmaFactory.NovoAlunoTurmaAtribuindoSomenteAluno(AlunoFactory.NovoAlunoCompleto(aluno.Id, aluno.Nome))).ToList()
                    )
                );
            CreateMap<AlunoViewModel, Aluno>();
            CreateMap<PeriodoAcademicoViewModel, PeriodoAcademico>();
        }
    }
}
