    using AutoMapper;
using CLINICAL.Application.Interface.Interfaces;
using CLINICAL.Application.UseCase.Commons.Bases;
using Entity = CLINICAL.Domain.Entities;
using MediatR;
using CLINICAL.Utilities.Constants;
using CLINICAL.Utilities.HelperExtensions;

namespace CLINICAL.Application.UseCase.UseCase.Analysis.Commands.ChangeStateCommand
{
    public class ChangeStateAnalysisHandler : IRequestHandler<ChangeStateAnalysisCommand, BaseResponse<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ChangeStateAnalysisHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<bool>> Handle(ChangeStateAnalysisCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<bool>();
            try
            {
                var analysis = _mapper.Map<Entity.Analysis>(request);
                var parameters = analysis.GetPropertiesWhithValues();
                response.Data = await _unitOfWork.Analysis.ExecAsync(SP.uspAnalysisChangeState, parameters);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = GlobalMessages.MESSAGE_UPDATE_STATE;
                }
            }catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            return response;
        }
    }
}
