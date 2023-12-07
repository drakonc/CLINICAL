using System.Data;
using CLINICAL.Application.Dto.Patient.Response;
using CLINICAL.Application.Interface.Interfaces;
using CLINICAL.Domain.Entities;
using CLINICAL.Persistence.Context;
using Dapper;

namespace CLINICAL.Persistence.Repositories
{
    public class PatientRepository : GenericRepository<Patient>, IPatientRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public PatientRepository(ApplicationDbContext dbContext): base(dbContext)
        {
            _dbContext = dbContext;    
        }

        public async Task<IEnumerable<GetAllPatientResponseDto>> GetAllPatient(string storedProcedure)
        {
            var connection = _dbContext.CreateConnection;
            var patient = await connection.QueryAsync<GetAllPatientResponseDto>(storedProcedure, commandType: CommandType.StoredProcedure);
            return patient;
        }

    }
}