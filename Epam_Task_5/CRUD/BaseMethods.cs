using Epam_Task_5.CRUD.Interfaces;
using Epam_Task_5.ORM.Tables;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using Epam_Task_5.Factory;


namespace Epam_Task_5.CRUD
{
    public class BaseMethods<T> : IBaseMethods<T> where T : BaseEntity
    {
        private SqlConnection _sqlConnection;
        private List<PropertyInfo> _properties;

        public BaseMethods(SqlConnection sqlConnection)
        {
            _sqlConnection = sqlConnection;
            _properties = typeof(T).GetProperties().ToList();
        }

        public void Create(T obj)
        {
            string sqlInsertCommand = $"SET IDENTITY_INSERT [{typeof(T).Name}] ON; INSERT INTO [{typeof(T).Name}] (";

            List<PropertyInfo> propertyColumns = _properties.Where(property => !property.PropertyType.IsClass || property.PropertyType == typeof(string)).ToList();

            sqlInsertCommand += string.Join(",", propertyColumns.Select(property => $"[{property.Name}]"));

            sqlInsertCommand += ")";
            sqlInsertCommand += "VALUES (";
            sqlInsertCommand += string.Join(",", propertyColumns.Select(property => $"@{property.Name}"));

            sqlInsertCommand += ");";
            sqlInsertCommand += $"SET IDENTITY_INSERT [{typeof(T).Name}] OFF;";

            var sqlCommand = new SqlCommand(sqlInsertCommand, _sqlConnection);

            foreach (PropertyInfo property in propertyColumns)
            {
                sqlCommand.Parameters.AddWithValue($"@{property.Name}", $"{property.GetValue(obj)}");
            }

            _sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            _sqlConnection.Close();
        }

        public T Read(int id)
        {
            _sqlConnection.Open();
            object obj = null;

            string sqlSelectCommand = $"SELECT * FROM [{typeof(T).Name}] WHERE Id = @Id;";
            SqlCommand sqlCommand = new SqlCommand(sqlSelectCommand, _sqlConnection);

            sqlCommand.Parameters.AddWithValue("@Id", $"{id}");

            SqlDataReader reader = sqlCommand.ExecuteReader();

            int count = reader.FieldCount;

            if (reader.HasRows)
            {
                reader.Read();
                obj = CustomFactory.CreateModel<T>();

                for (int i = 0; i < count; i++)
                {
                    var fieldName = reader.GetName(i);
                    var propInfo = typeof(T).GetProperty(fieldName);
                    propInfo?.SetValue(obj, reader.GetValue(i));
                }
            }

            _sqlConnection.Close();

            return (T)obj;
        }

        public void Update(int id, T obj)
        {
            string sqlUpdateCommand = $"UPDATE [{typeof(T).Name}] SET ";

            List<PropertyInfo> propertyColumns = _properties.Where(property => (!property.PropertyType.IsClass || (property.PropertyType == typeof(string))) &&
                                                                               (property.Name != nameof(BaseEntity.Id))).ToList();

            sqlUpdateCommand += string.Join(",", propertyColumns.Where(prop => (prop.Name != nameof(BaseEntity.Id)))
                                                                .Select(property => string.Format($"[{property.Name}] = @{property.Name} ")));

            sqlUpdateCommand += $"WHERE [ID] = @{nameof(id)};";

            SqlCommand sqlCommand = new SqlCommand(sqlUpdateCommand, _sqlConnection);

            foreach (PropertyInfo property in propertyColumns)
            {
                sqlCommand.Parameters.AddWithValue($"@{property.Name}", $"{property.GetValue(obj)}");
            }

            sqlCommand.Parameters.AddWithValue($"@{nameof(id)}", $"{id}");

            _sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            _sqlConnection.Close();
        }

        public void Delete(int id)
        {
            string sqlDeleteCommand = $"DELETE FROM [{typeof(T).Name}] WHERE ID = @ID;";

            SqlCommand sqlCommand = new SqlCommand(sqlDeleteCommand, _sqlConnection);

            sqlCommand.Parameters.AddWithValue("@ID", $"{id}");

            _sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            _sqlConnection.Close();
        }

    }
}
