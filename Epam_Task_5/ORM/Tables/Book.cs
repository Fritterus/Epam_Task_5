using System;
using System.Collections.Generic;
using System.Text;

namespace Epam_Task_5.ORM.Tables
{
    /// <summary>
    /// Class describing book model
    /// </summary>
    public class Book : BaseEntity
    {
        public string Name { get; set; }
        public int GenreId { get; set; }
        public int AuthorId { get; set; }

        /// <summary>
        /// Method for equal the current object with the specified object
        /// </summary>
        /// <param name="obj">Any object</param>
        /// <returns>True or False</returns>
        public override bool Equals(object obj)
        {
            return obj is Book book &&
                   base.Equals(obj) &&
                   Id == book.Id &&
                   Name == book.Name &&
                   GenreId == book.GenreId &&
                   AuthorId == book.AuthorId;
        }

        /// <summary>
        /// The method calculates the hash code for the current object
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), Id, Name, GenreId, AuthorId);
        }

        /// <summary>
        /// The method creates and returns a string representation of the object
        /// </summary>
        /// <returns>String representation</returns>
        public override string ToString()
        {
            return base.ToString() + string.Format($"Name {Name}"
                                                   + $"GenreId {GenreId}"
                                                   + $"AuthorId {AuthorId}");
        }
    }
}
