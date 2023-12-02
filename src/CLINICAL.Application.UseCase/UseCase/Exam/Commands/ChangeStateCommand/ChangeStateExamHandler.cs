using AutoMapper;
using CLINICAL.Application.Interface.Interfaces;
using CLINICAL.Application.UseCase.Commons.Bases;
using Entity = CLINICAL.Domain.Entities;
using MediatR;
using CLINICAL.Utilities.HelperExtensions;
using CLINICAL.Utilities.Constants;

namespace CLINICAL.Application.UseCase.UseCase.Exam.Commands.ChangeStateCommand
{
    internal class ChangeStateExamHandler : IRequestHandler<ChangeStateExamCommand, BaseResponse<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ChangeStateExamHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<bool>> Handle(ChangeStateExamCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<bool>();
            try
            {
                var exam = _mapper.Map<Entity.Exam>(request);
                var parameters = exam.GetPropertiesWhithValues();
                response.Data = await _unitOfWork.Exam.ExecAsync(SP.uspExamChangeState, parameters);
                if (response.Data)
                {
                    response.IsSuccess = false;
                    response.Message = GlobalMessages.MESSAGE_UPDATE_STATE;
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = GlobalMessages.MESSAGE_ERROR_UPDATE_STATE;
                }
            }
            catch(Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            return response;
        }
    }
}
