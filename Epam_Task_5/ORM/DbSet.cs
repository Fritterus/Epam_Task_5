using Epam_Task_5.ORM.Tables;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Epam_Task_5.ORM
{
    public class DbSet<T> : IEnumerable<T> where T : BaseEntity 
    {
        private List<T> _listModel;
        private SqlConnection _sqlConnection;

        public DbSet(SqlConnection sqlConnection)
        {
            if (sqlConnection == null)
            {
                throw new Exception($"{nameof(SqlConnection)} cannot be null.");
            }

            _sqlConnection = sqlConnection;
        }

        public void Add(T item)
        {

        }
    }
}
