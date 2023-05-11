using AutoMapper;
using CLINICAL.Application.Dto.Analysis.Response;
using CLINICAL.Application.UseCase.UseCase.Analysis.Commands.CreateCommand;
using CLINICAL.Application.UseCase.UseCase.Analysis.Commands.UpdateCommand;
using CLINICAL.Domain.Entities;

namespace CLINICAL.Application.UseCase.Mappings
{
    public class AnalysisMappingProfile : Profile
    {
        public AnalysisMappingProfile()
        {
            CreateMap<Analysis, GetAllAnalysisResponseDto>()
                .ForMember(x => x.StateAnalysis, x => x.MapFrom(y => y.State == 1 ? "ACTIVO" : "INACTIVO"))
                .ReverseMap();

            CreateMap<Analysis, GetAnalysisByIdResponseDto>()
               .ReverseMap();

            CreateMap<CreateAnalysisCommand, Analysis>();
            CreateMap<UpdateAnalysisCommand, Analysis>();

        }
    }
}
