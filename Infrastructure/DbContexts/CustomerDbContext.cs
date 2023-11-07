using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Data.SqlClient;

namespace Infrastructure.DbContexts
{
    public class CustomerDbContext : DbContext
    {
        private readonly string _connectionString;

        public CustomerDbContext(
            string connectionString
            )
        {
            _connectionString = connectionString;
        }

        public IDbConnection GetDbConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
