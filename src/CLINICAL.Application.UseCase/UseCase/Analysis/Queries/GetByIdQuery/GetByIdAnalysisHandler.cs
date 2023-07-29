using AutoMapper;
using CLINICAL.Application.Dto.Analysis.Response;
using CLINICAL.Application.Interface.Interfaces;
using CLINICAL.Application.UseCase.Commons.Bases;
using CLINICAL.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLINICAL.Application.UseCase.UseCase.Analysis.Queries.GetByIdQuery
{
    public class GetByIdAnalysisHandler : IRequestHandler<GetByIdAnalysisQuery, BaseResponse<GetAnalysisByIdResponseDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetByIdAnalysisHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<GetAnalysisByIdResponseDto>> Handle(GetByIdAnalysisQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<GetAnalysisByIdResponseDto>();
            try
            {
                var analysis = await _unitOfWork.Analysis.GetByIdAsync("uspAnalysisById", new { request.AnalysisId });

                if (analysis is null)
                {
                    response.IsSuccess = false;
                    response.Message = "No se encontraron registros";
                    return response;
                }

                response.IsSuccess = true;
                response.Message = "Consulta Esitosa!!";
                response.Data = _mapper.Map<GetAnalysisByIdResponseDto>(analysis);
            }
            catch(Exception ex)
            {
                response.Message = ex.ToString();
            }

            return response;
        }
    }
}
