using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DapperECommerce.Data
{
    public class Context
    {
        private readonly IConfiguration _configuration;

        public Context(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private IDbConnection Connection =>
            new SqlConnection(_configuration.GetConnectionString("Default"));

        public IEnumerable<T> Query<T>(string sp, object param = null)
        {
            return Connection.Query<T>(
                sp,
                param,
                commandType: CommandType.StoredProcedure);
        }

        public void Execute(string sp, object param = null)
        {
            Connection.Execute(
                sp,
                param,
                commandType: CommandType.StoredProcedure);
        }
    }
}