using CLINICAL.Application.UseCase.Commons.Bases;
using MediatR;

namespace CLINICAL.Application.UseCase.UseCase.Exam.Commands.UpdateCommand
{
    public class UpdateExamCommand :IRequest<BaseResponse<bool>>
    {
        public int ExamId { get; set; }
        public int AnalysisId { get; set; }
        public string? Name { get; set; }
    }
}
