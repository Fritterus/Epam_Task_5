using System;
using System.Collections.Generic;
using System.Text;

namespace Epam_Task_5.ORM.Tables
{
    /// <summary>
    /// Class describing subscriber model
    /// </summary>
    public class Subscriber : BaseEntity
    {
        public string FullName { get; set; }
        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }

        /// <summary>
        /// Method for equal the current object with the specified object
        /// </summary>
        /// <param name="obj">Any object</param>
        /// <returns>True or False</returns>
        public override bool Equals(object obj)
        {
            return obj is Subscriber subscriber &&
                   base.Equals(obj) &&
                   Id == subscriber.Id &&
                   FullName == subscriber.FullName &&
                   Gender == subscriber.Gender &&
                   BirthDate == subscriber.BirthDate;
        }

        /// <summary>
        /// The method calculates the hash code for the current object
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), Id, FullName, Gender, BirthDate);
        }

        /// <summary>
        /// The method creates and returns a string representation of the object
        /// </summary>
        /// <returns>String representation</returns>
        public override string ToString()
        {
            return base.ToString() + string.Format($"FullName {FullName}"
                                                   + $"Gender {Gender}"
                                                   + $"BirthDate {BirthDate}");
        }
    }
}
