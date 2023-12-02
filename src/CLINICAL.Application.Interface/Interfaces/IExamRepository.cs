using CLINICAL.Application.Dto.Exam.Response;
using CLINICAL.Domain.Entities;


namespace CLINICAL.Application.Interface.Interfaces
{
    public interface IExamRepository: IGenericRepository<Exam>
    {
        Task<IEnumerable<GetAllExamResponseDto>> GetAllExans(string storeProcedure);
    }
}
