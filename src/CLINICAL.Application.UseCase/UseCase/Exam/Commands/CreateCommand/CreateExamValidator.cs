using FluentValidation;

namespace CLINICAL.Application.UseCase.UseCase.Exam.Commands.CreateCommand
{
    public class CreateExamValidator: AbstractValidator<CreateExamCommand>
    {
        public CreateExamValidator()
        {
            RuleFor(x => x.Name)
                .NotNull().WithMessage("El Campo Nombre no puede ser null.")
                .NotEmpty().WithMessage("El Campo Nombre no puede estar vacio.");

            RuleFor(x => x.AnalysisId)
                .NotNull().WithMessage("El Campo AnalysisId no puede ser null.")
                .NotEmpty().WithMessage("El Campo AnalysisId no puede estar vacio.");
        }
    }
}
