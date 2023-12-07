using AutoMapper;
using CLINICAL.Application.Dto.Patient.Response;
using Entity = CLINICAL.Domain.Entities;

namespace CLINICAL.Application.UseCase.Mappings
{
    public class ParentMappingProfile : Profile
    {
        public ParentMappingProfile()
        {
            CreateMap<Entity.Patient,GetPatientByIdResponseDto>()
                .ReverseMap();
        }
    }
}