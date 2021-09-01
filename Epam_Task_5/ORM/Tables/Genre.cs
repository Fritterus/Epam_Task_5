using System;
using System.Collections.Generic;
using System.Text;

namespace Epam_Task_5.ORM.Tables
{
    /// <summary>
    /// Class describing genre model
    /// </summary>
    public class Genre : BaseEntity
    {
        public string Name { get; set; }

        /// <summary>
        /// Method for equal the current object with the specified object
        /// </summary>
        /// <param name="obj">Any object</param>
        /// <returns>True or False</returns>
        public override bool Equals(object obj)
        {
            return obj is Genre genre &&
                   base.Equals(obj) &&
                   Id == genre.Id &&
                   Name == genre.Name;
        }

        /// <summary>
        /// The method calculates the hash code for the current object
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), Id, Name);
        }

        /// <summary>
        /// The method creates and returns a string representation of the object
        /// </summary>
        /// <returns>String representation</returns>
        public override string ToString()
        {
            return base.ToString() + string.Format($"Name {Name}");
        }
    }
}
