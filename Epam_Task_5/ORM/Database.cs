using Epam_Task_5.ORM.Tables;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Epam_Task_5.ORM
{
    /// <summary>
    /// Class for storing database table
    /// </summary>
    public class Database : DbContext
    {
        private static Database _instance;

        public DbSet<Subscriber> Subscribers { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<History> Histories { get; set; }

        /// <summary>
        /// Constructor for initializes tables
        /// </summary>
        private Database() :
            base()
        {
            Subscribers = new DbSet<Subscriber>(_sqlConnection);
            Books = new DbSet<Book>(_sqlConnection);
            Genres = new DbSet<Genre>(_sqlConnection);
            Authors = new DbSet<Author>(_sqlConnection);
            Histories = new DbSet<History>(_sqlConnection);
        }

        public static Database Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Database();
                }

                return _instance;
            }
        }

        /// <summary>
        /// Method for equal the current object with the specified object
        /// </summary>
        /// <param name="obj">Any object</param>
        /// <returns>True or False</returns>
        public override bool Equals(object obj)
        {
            return obj is Database database &&
                   EqualityComparer<SqlConnection>.Default.Equals(_sqlConnection, database._sqlConnection) &&
                   EqualityComparer<DbSet<Subscriber>>.Default.Equals(Subscribers, database.Subscribers) &&
                   EqualityComparer<DbSet<Book>>.Default.Equals(Books, database.Books) &&
                   EqualityComparer<DbSet<Genre>>.Default.Equals(Genres, database.Genres) &&
                   EqualityComparer<DbSet<Author>>.Default.Equals(Authors, database.Authors) &&
                   EqualityComparer<DbSet<History>>.Default.Equals(Histories, database.Histories);
        }

        /// <summary>
        /// The method calculates the hash code for the current object
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(_sqlConnection, Subscribers, Books, Genres, Authors, Histories);
        }
    }
}
