using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Epam_Task_5.ORM
{
    public abstract class DbContext
    {
        private string _connectionString;
        protected SqlConnection _sqlConnection;
        public DbContext()
        {
            _connectionString = @"";
            _sqlConnection = new SqlConnection(_connectionString);
        }
    }
}
