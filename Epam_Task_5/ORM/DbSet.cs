using Epam_Task_5.CRUD;
using Epam_Task_5.Factory;
using Epam_Task_5.ORM.Tables;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;

namespace Epam_Task_5.ORM
{
    /// <summary>
    /// Class for storing a table as a collection of objects
    /// </summary>
    /// <typeparam name="T">Class that inherits the class BaseEntity</typeparam>
    public class DbSet<T> : IEnumerable<T> where T : BaseEntity 
    {
        private BaseMethods<T> _baseMethods;
        private List<T> _listModel;
        private SqlConnection _sqlConnection;

        /// <summary>
        /// Constructor set up SqlConnection and reads the table into the collection of objects
        /// </summary>
        /// <param name="sqlConnection"></param>
        public DbSet(SqlConnection sqlConnection)
        {
            _sqlConnection = sqlConnection ?? throw new Exception($"{nameof(SqlConnection)} cannot be null.");
            _baseMethods = new BaseMethods<T>(_sqlConnection);
            _listModel = ReadTable().ToList();
        }

        /// <summary>
        /// Method add an object to the objects collection and to the table
        /// </summary>
        /// <param name="item"></param>
        public void Add(T item)
        {
            _baseMethods.Create(item);
            _listModel.Add(item);
        }

        /// <summary>
        /// Method delete an object from the objects collection and from the table
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            _baseMethods.Delete(id);

            var deletedModel = _listModel.FirstOrDefault(o => o.Id == id);
            _listModel.Remove(deletedModel);
        }

        /// <summary>
        /// Method update an object in the objects collection and in the table
        /// </summary>
        /// <param name="id"></param>
        /// <param name="item"></param>
        public void Update(int id, T item)
        {
            _baseMethods.Update(id, item);

            var updatedModel = _listModel.FirstOrDefault(o => o.Id == id);
            updatedModel = item;
        }

        /// <summary>
        /// Method read an object from the objects collection
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T Read(int id) => _listModel.FirstOrDefault(o => o.Id == id);

        public IEnumerator<T> GetEnumerator() => _listModel.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Method read a table from a database
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T> ReadTable()
        {
            _sqlConnection.Open();

            var sqlSelectCommand = $"SELECT * FROM [{typeof(T).Name}]";
            var sqlCommand = new SqlCommand(sqlSelectCommand, _sqlConnection);
            SqlDataReader reader = sqlCommand.ExecuteReader();

            var list = new List<T>();
            var obj = CustomFactory.CreateModel<T>();

            int columnsNumber = reader.FieldCount;

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    for (var i = 0; i < columnsNumber; i++)
                    {
                        string fieldName = reader.GetName(i);
                        PropertyInfo propInfo = obj.GetType().GetProperty(fieldName);

                        if (!(reader.GetValue(i) is DBNull))
                        {
                            propInfo?.SetValue(obj, reader.GetValue(i));
                        }
                    }

                    list.Add((T)obj);
                    obj = CustomFactory.CreateModel(typeof(T).FullName);
                }
            }

            _sqlConnection.Close();

            return list;
        }

    }
}
