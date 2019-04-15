using FluentValidation;
using TesteUolEdtech.Domain.Models;

namespace TesteUolEdtech.Domain.Cursos.Validations
{
    public class CursoValidation : AbstractValidator<Curso>
    {
        public CursoValidation()
        {
        }
    }
}
