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
            _connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Db_Task_5;Integrated Security=True";
            _sqlConnection = new SqlConnection(_connectionString);
        }

        public override bool Equals(object obj)
        {
            return obj is DbContext context &&
                   _connectionString == context._connectionString &&
                   EqualityComparer<SqlConnection>.Default.Equals(_sqlConnection, context._sqlConnection);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_connectionString, _sqlConnection);
        }
    }
}
