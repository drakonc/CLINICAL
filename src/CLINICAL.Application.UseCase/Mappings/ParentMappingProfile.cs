using AutoMapper;
using CLINICAL.Application.Dto.Patient.Response;
using CLINICAL.Application.UseCase.UseCase.Patient.Command.CreateCommand;
using Entity = CLINICAL.Domain.Entities;

namespace CLINICAL.Application.UseCase.Mappings
{
    public class ParentMappingProfile : Profile
    {
        public ParentMappingProfile()
        {
            CreateMap<Entity.Patient,GetPatientByIdResponseDto>()
                .ReverseMap();

            CreateMap<CreatePatientCommand,Entity.Patient>();
        }
    }
}