using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLINICAL.Application.UseCase.UseCase.Exam.Commands.UpdateCommand
{
    public class UpdateExamValidator: AbstractValidator<UpdateExamCommand>
    {
        public UpdateExamValidator()
        {
            RuleFor(x => x.ExamId)
                .NotNull().WithMessage("El Campo ExamId no puede ser null.")
                .NotEmpty().WithMessage("El Campo ExamId no puede estar vacio.");

            RuleFor(x => x.Name)
                .NotNull().WithMessage("El Campo Nombre no puede ser null.")
                .NotEmpty().WithMessage("El Campo Nombre no puede estar vacio.");

            RuleFor(x => x.AnalysisId)
                .NotNull().WithMessage("El Campo AnalysisId no puede ser null.")
                .NotEmpty().WithMessage("El Campo AnalysisId no puede estar vacio.");
        }
    }
}
