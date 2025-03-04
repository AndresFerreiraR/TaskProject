using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace TaskProjects.Persistence.Context
{
    public class DapperContext
    {
        private readonly IConfiguration _configuraton;
        private readonly string _connectionString;

        public DapperContext(IConfiguration configuraton)
        {
            _configuraton = configuraton;
            _connectionString = _configuraton.GetConnectionString("DefaultConnectionString");
        }

        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
    }
}