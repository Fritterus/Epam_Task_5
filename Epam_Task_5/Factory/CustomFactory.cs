using Epam_Task_5.ORM.Tables;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Epam_Task_5.Factory
{
    public static class CustomFactory
    {
        public static BaseEntity CreateModel<T>() where T : BaseEntity
        {
            return Activator.CreateInstance<T>();
        }

        public static BaseEntity CreateModel(string fullName)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var type = assembly.GetType(fullName).FullName;
            return (BaseEntity)Activator.CreateInstanceFrom(assembly.Location, type).Unwrap();
        }
    }
}
