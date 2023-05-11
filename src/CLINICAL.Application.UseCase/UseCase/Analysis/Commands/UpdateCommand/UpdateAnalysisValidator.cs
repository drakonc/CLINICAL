using FluentValidation;

namespace CLINICAL.Application.UseCase.UseCase.Analysis.Commands.UpdateCommand
{
    public class UpdateAnalysisValidator : AbstractValidator<UpdateAnalysisCommand>
    {
        public UpdateAnalysisValidator()
        {
            RuleFor(x => x.AnalysisId)
                .NotNull().WithMessage("El Campo AnalysisId no puede ser nulo")
                .NotEmpty().WithMessage("El campo AnalysisId no puede ser vacio.");

            RuleFor(x => x.Name)
                .NotNull().WithMessage("El Campo Nombre no puede ser nulo")
                .NotEmpty().WithMessage("El campo Nombre no puede ser vacio.");
        }
    }
}
