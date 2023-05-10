using AutoMapper;
using CLINICAL.Application.Dto.Analysis.Response;
using CLINICAL.Application.Interface;
using CLINICAL.Application.UseCase.Commons.Bases;
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
        private readonly IAnalysisRepository _analysisRepository;
        private readonly IMapper _mapper;

        public GetByIdAnalysisHandler(IAnalysisRepository analysisRepository, IMapper mapper)
        {
            _analysisRepository = analysisRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse<GetAnalysisByIdResponseDto>> Handle(GetByIdAnalysisQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<GetAnalysisByIdResponseDto>();
            try
            {
                var analysis = await _analysisRepository.AnalysisById(request.AnalysisId);

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
