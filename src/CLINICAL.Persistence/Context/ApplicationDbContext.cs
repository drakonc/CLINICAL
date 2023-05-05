using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace CLINICAL.Persistence.Context
{
    public class ApplicationDbContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public ApplicationDbContext(IConfiguration configuration, string connectionString)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("ClinicalConnection")!;
        }

        public IDbConnection CreateConnection => new SqlConnection(_connectionString);
    }
}
