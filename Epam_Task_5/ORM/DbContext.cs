using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Epam_Task_5.ORM
{
    /// <summary>
    /// Class for setting connection to database
    /// </summary>
    public abstract class DbContext
    {
        private string _connectionString;
        protected SqlConnection _sqlConnection;

        /// <summary>
        /// Constructor for initializes SqlConnection
        /// </summary>
        public DbContext()
        {
            _connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Db_Task_5;Integrated Security=True";
            _sqlConnection = new SqlConnection(_connectionString);
        }

        /// <summary>
        /// Method for equal the current object with the specified object
        /// </summary>
        /// <param name="obj">Any object</param>
        /// <returns>True or False</returns>
        public override bool Equals(object obj)
        {
            return obj is DbContext context &&
                   _connectionString == context._connectionString &&
                   EqualityComparer<SqlConnection>.Default.Equals(_sqlConnection, context._sqlConnection);
        }

        /// <summary>
        /// The method calculates the hash code for the current object
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(_connectionString, _sqlConnection);
        }
    }
}
