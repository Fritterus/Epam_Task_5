using Epam_Task_5.ORM.Tables;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Epam_Task_5.Factory
{
    /// <summary>
    /// Class for creating any object
    /// </summary>
    public static class CustomFactory
    {
        /// <summary>
        /// Method create an object that inherits class BaseEntity
        /// </summary>
        /// <typeparam name="T">Class that inherits class BaseEntity</typeparam>
        /// <returns></returns>
        public static BaseEntity CreateModel<T>() where T : BaseEntity
        {
            return Activator.CreateInstance<T>();
        }

        /// <summary>
        /// Method create an object whose name is passed to method
        /// </summary>
        /// <param name="fullName"></param>
        /// <returns></returns>
        public static BaseEntity CreateModel(string fullName)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var type = assembly.GetType(fullName).FullName;
            return (BaseEntity)Activator.CreateInstanceFrom(assembly.Location, type).Unwrap();
        }
    }
}
