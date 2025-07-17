using FluentValidation;
using Q10.Domain.Entities;

namespace Q10.Domain.Validator
{
    public class SubjectValidator : AbstractValidator<Subject>
    {
        public SubjectValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("El nombre es obligatorio")
                .MaximumLength(100).WithMessage("El nombre no puede superar los 100 caracteres");

            RuleFor(x => x.Code)
                .NotEmpty().WithMessage("El código es obligatorio")
                .MaximumLength(15).WithMessage("El código no puede superar los 15 caracteres");

            RuleFor(x => x.Credit)
                .InclusiveBetween(1, 10).WithMessage("El crédito debe estar entre 1 y 10");
        }
    }
}
