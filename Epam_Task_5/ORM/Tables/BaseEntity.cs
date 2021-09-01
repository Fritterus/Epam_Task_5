using System;
using System.Collections.Generic;
using System.Text;

namespace Epam_Task_5.ORM.Tables
{
    /// <summary>
    /// Class describing base entity model
    /// </summary>
    public class BaseEntity
    {
        public int Id { get; set; }

        /// <summary>
        /// Method for equal the current object with the specified object
        /// </summary>
        /// <param name="obj">Any object</param>
        /// <returns>True or False</returns>
        public override bool Equals(object obj)
        {
            return obj is BaseEntity entity &&
                   Id == entity.Id;
        }

        /// <summary>
        /// The method calculates the hash code for the current object
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }

        /// <summary>
        /// The method creates and returns a string representation of the object
        /// </summary>
        /// <returns>String representation</returns>
        public override string ToString()
        {
            return string.Format($"Id: {Id}\n");
        }
    }
}
