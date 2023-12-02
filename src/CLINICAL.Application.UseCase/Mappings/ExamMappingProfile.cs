using AutoMapper;
using CLINICAL.Application.Dto.Exam.Response;
using CLINICAL.Application.UseCase.UseCase.Exam.Commands.ChangeStateCommand;
using CLINICAL.Application.UseCase.UseCase.Exam.Commands.CreateCommand;
using CLINICAL.Application.UseCase.UseCase.Exam.Commands.UpdateCommand;
using CLINICAL.Domain.Entities;

namespace CLINICAL.Application.UseCase.Mappings
{
    public class ExamMappingProfile : Profile
    {
        public ExamMappingProfile()
        {
            CreateMap<Exam,GetExamByIdResponseDto>()
                .ReverseMap();

            CreateMap<CreateExamCommand,Exam>();
            CreateMap<UpdateExamCommand, Exam>();
            CreateMap<ChangeStateExamCommand, Exam>();
        }
    }
}
