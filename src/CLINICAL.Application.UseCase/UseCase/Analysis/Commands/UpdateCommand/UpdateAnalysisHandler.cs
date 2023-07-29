using AutoMapper;
using CLINICAL.Application.Interface.Interfaces;
using CLINICAL.Application.UseCase.Commons.Bases;
using MediatR;
using Entity = CLINICAL.Domain.Entities;

namespace CLINICAL.Application.UseCase.UseCase.Analysis.Commands.UpdateCommand
{
    public class UpdateAnalysisHandler : IRequestHandler<UpdateAnalysisCommand, BaseResponse<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateAnalysisHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<bool>> Handle(UpdateAnalysisCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<bool>();
            try
            {
                var analysis = _mapper.Map<Entity.Analysis>(request);
                response.Data = await _unitOfWork.Analysis.ExecAsync("uspAnalysisEdid", new { analysis.AnalysisId, analysis.Name });
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Se actualizo correctamente.";
                }

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }
    }
}
