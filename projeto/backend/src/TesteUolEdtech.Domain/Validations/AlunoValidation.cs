using FluentValidation;
using TesteUolEdtech.Domain.Models;

namespace TesteUolEdtech.Domain.Cursos.Validations
{
    public class AlunoValidation : AbstractValidator<Aluno>
    {
        public AlunoValidation()
        {
        }
    }
}
