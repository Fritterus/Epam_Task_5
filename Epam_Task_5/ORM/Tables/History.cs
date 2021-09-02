using System;
using System.Collections.Generic;
using System.Text;

namespace Epam_Task_5.ORM.Tables
{
    /// <summary>
    /// Class describing history model
    /// </summary>
    public class History : BaseEntity
    {
        public DateTime ReceivingDate { get; set; }
        public int BookId { get; set; }
        public int SubscriberId { get; set; }
        public bool IsReturn { get; set; }
        public string BookCondition { get; set; }

        /// <summary>
        /// Method for equal the current object with the specified object
        /// </summary>
        /// <param name="obj">Any object</param>
        /// <returns>True or False</returns>
        public override bool Equals(object obj)
        {
            return obj is History history &&
                   base.Equals(obj) &&
                   Id == history.Id &&
                   ReceivingDate == history.ReceivingDate &&
                   SubscriberId == history.SubscriberId &&
                   IsReturn == history.IsReturn &&
                   BookCondition == history.BookCondition;
        }

        /// <summary>
        /// The method calculates the hash code for the current object
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), Id, ReceivingDate, SubscriberId, IsReturn, BookCondition);
        }

        /// <summary>
        /// The method creates and returns a string representation of the object
        /// </summary>
        /// <returns>String representation</returns>
        public override string ToString()
        {
            return base.ToString() + string.Format($"ReceivingDate {ReceivingDate}"
                                                   + $"SubscriberId {SubscriberId}"
                                                   + $"IsReturn {IsReturn}"
                                                   + $"BookCondition {BookCondition}");
        }
    }
}
