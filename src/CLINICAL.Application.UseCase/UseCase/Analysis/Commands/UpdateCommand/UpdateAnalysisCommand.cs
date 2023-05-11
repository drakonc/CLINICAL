using CLINICAL.Application.UseCase.Commons.Bases;
using MediatR;

namespace CLINICAL.Application.UseCase.UseCase.Analysis.Commands.UpdateCommand
{
    public class UpdateAnalysisCommand : IRequest<BaseResponse<bool>>
    {
        public int AnalysisId { get; set; }
        public string? Name { get; set; }
    }
}
