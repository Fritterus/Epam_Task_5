using Epam_Task_5.ORM;
using System.IO;
using System.Linq;

namespace Epam_Task_5.Reports.FileWork
{
    /// <summary>
    /// Class for work with txt file
    /// </summary>
    public class TxtFormat
    {
        /// <summary>
        /// Method for write any popular in txt file
        /// </summary>
        /// <param name="filePath"></param>
        public static void WriteAnyPopularInTxtFile(string filePath)
        {
            Database database = Database.Instance;
            var books = database.Books.ToList();
            var genres = database.Genres.ToList();
            var authors = database.Authors.ToList();
            var subscribers = database.Subscribers.ToList();
            var histories = database.Histories.ToList();

            var popularAuthorName = Report.GetMostPopularAuthor(books, authors).Name;
            var subscriberFullName = Report.GetMostReadingSubscriber(histories, subscribers).FullName;
            var popularGenreName = Report.GetPopularGenre(books, genres).Name;

            using var streamWriter = new StreamWriter(filePath);
            streamWriter.WriteLine("Popular Author\t\tSubscriber\t\t\t\t\t\t\t\tPopular Genre");
            streamWriter.WriteLine($"{popularAuthorName}\t\t\t\t{subscriberFullName}\t\t\t{popularGenreName}");
        }

        /// <summary>
        /// Method for write quantity borrowed books in txt file
        /// </summary>
        /// <param name="filePath"></param>
        public static void WriteBorrowedBooksInTxtFile(string filePath)
        {
            Database database = Database.Instance;
            var books = database.Books.ToList();
            var histories = database.Histories.ToList();

            var quantityBorrowedBooks = Report.GetQuantityBorrowedBooks(books, histories).Values.ToArray();


            using var streamWriter = new StreamWriter(filePath);
            streamWriter.WriteLine("Book Name\t\tQuantity Borrowed");

            for (int i = 0; i < books.Count(); i++)
            {
                streamWriter.Write(books[i].Name);
                streamWriter.Write("\t\t\t\t");
                streamWriter.WriteLine(quantityBorrowedBooks[i]);
            }
        }

        /// <summary>
        /// Method for write shabby books list in txt file
        /// </summary>
        /// <param name="filePath"></param>
        public static void WriteShabbyBooksInTxtFile(string filePath)
        {
            Database database = Database.Instance;
            var books = database.Books.ToList();
            var histories = database.Histories.ToList();
            var shabbyBooksList = Report.GetShabbyBookList(books, histories);


            using var streamWriter = new StreamWriter(filePath);
            streamWriter.WriteLine("Id\t\tName");

            for (int i = 0; i < shabbyBooksList.Count(); i++)
            {
                streamWriter.Write(shabbyBooksList[i].Id);
                streamWriter.Write("\t\t");
                streamWriter.WriteLine(shabbyBooksList[i].Name);
            }
        }
    }
}
