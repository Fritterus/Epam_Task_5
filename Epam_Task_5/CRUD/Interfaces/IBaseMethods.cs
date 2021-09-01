using Epam_Task_5.ORM.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace Epam_Task_5.CRUD.Interfaces
{
    public interface IBaseMethods<T> where T : BaseEntity
    {
        void Create(T obj);
        T Read(int id);
        void Update(int id, T obj);
        void Delete(int id);
    }
}
