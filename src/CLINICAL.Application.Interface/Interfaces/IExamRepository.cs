using CLINICAL.Application.Dto.Exam.Response;


namespace CLINICAL.Application.Interface.Interfaces
{
    public interface IExamRepository
    {
        Task<IEnumerable<GetAllExamResponseDto>> GetAllExans(string storeProcedure);
    }
}
