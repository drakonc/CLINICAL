using FluentValidation;

namespace CLINICAL.Application.UseCase.UseCase.Analysis.Commands.CreateCommand
{
    public class CreateAnalysisValidator : AbstractValidator<CreateAnalysisCommand>
    {
        public CreateAnalysisValidator()
        {
            RuleFor( x => x.Name )
                .NotNull().WithMessage("El Campo Nombre no puede ser nulo")
                .NotEmpty().WithMessage("El campo Nombre no puede ser vacio.");
        }
    }
}
