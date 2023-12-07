using CLINICAL.Application.Dto.Patient.Response;
using CLINICAL.Application.UseCase.Commons.Bases;
using MediatR;

namespace CLINICAL.Application.UseCase.Patient.Queries.GetByIdQuery
{
    public class GetByIdPatientQuery : IRequest<BaseResponse<GetPatientByIdResponseDto>>
    {
        public int PatienId { get; set; }
    }
}