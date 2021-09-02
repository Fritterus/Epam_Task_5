using Epam_Task_5.ORM.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epam_Task_5.Reports
{
    public class Report
    {
        public static Genre GetPopularGenre(List<Book> books, List<Genre> genres)
        {
            var dictionary = new Dictionary<int, int>();

            foreach (var book in books)
            {
                var bookId = 0;

                if(dictionary.TryGetValue(book.GenreId, out bookId))
                {
                    dictionary[book.GenreId]++;
                
                }
                else
                {
                    dictionary.Add(book.GenreId, 1);
                }
            }

            var popularGenreId = dictionary.First(o => o.Value == dictionary.Max(e => e.Value)).Key;

            return genres.First(o => o.Id == popularGenreId);
        }

        public static Subscriber GetMostReadingSubscriber(List<History> histories, List<Subscriber> subscribers)
        {
            var dictionary = new Dictionary<int, int>();

            foreach (var history in histories)
            {
                var historyId = 0;

                if (dictionary.TryGetValue(history.SubscriberId, out historyId))
                {
                    dictionary[history.SubscriberId]++;

                }
                else
                {
                    dictionary.Add(history.SubscriberId, 1);
                }
            }

            var mostReadingSubscriberId = dictionary.First(o => o.Value == dictionary.Max(e => e.Value)).Key;

            return subscribers.First(o => o.Id == mostReadingSubscriberId);
        }

        public static Author GetMostPopularAuthor(List<Book> books, List<Author> authors)
        {
            var dictionary = new Dictionary<int, int>();

            foreach (var book in books)
            {
                var bookId = 0;

                if (dictionary.TryGetValue(book.AuthorId, out bookId))
                {
                    dictionary[book.AuthorId]++;

                }
                else
                {
                    dictionary.Add(book.AuthorId, 1);
                }
            }

            var mostPopularAuthorId = dictionary.First(o => o.Value == dictionary.Max(e => e.Value)).Key;

            return authors.First(o => o.Id == mostPopularAuthorId);
        }

        public static Dictionary<int, int> GetQuantityBorrowedBooks(List<Book> books, List<History> histories)
        {
            var quantityBorrowedBooks = new Dictionary<int, int>();

            foreach (var book in books)
            {
                quantityBorrowedBooks.Add(book.Id, 0);
            }

            for (int i = 0; i < books.Count(); i++)
            {
                for (int j = 0; j < histories.Count(); j++)
                {
                    if (books[i].Id == histories[j].BookId)
                    {
                        quantityBorrowedBooks[books[i].Id]++;
                    }
                }
            }

            return quantityBorrowedBooks;
        }

        public static List<Book> GetShabbyBookList(List<Book> books, List<History> histories)
        {
            var shabbyBooks = new List<Book>();

            for (int i = 0; i < histories.Count(); i++)
            {
                if (histories[i].BookCondition == "Shabby")
                {
                    shabbyBooks.Add(books.First(o => o.Id == histories[i].BookId));
                }
            }

            return shabbyBooks;
        }

    }
}
