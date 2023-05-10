using CLINICAL.Application.Dto.Analysis.Response;
using CLINICAL.Application.UseCase.Commons.Bases;
using MediatR;

namespace CLINICAL.Application.UseCase.UseCase.Analysis.Queries.GetByIdQuery
{
    public class GetByIdAnalysisQuery : IRequest<BaseResponse<GetAnalysisByIdResponseDto>>
    {
        public int AnalysisId { get; set; }
    }
}
