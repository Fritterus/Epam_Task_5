using Epam_Task_5.CRUD;
using Epam_Task_5.Factory;
using Epam_Task_5.ORM;
using Epam_Task_5.ORM.Tables;
using Epam_Task_5.Reports;
using NUnit.Framework;
using System;
using System.Data.SqlClient;
using System.Linq;

namespace Tests
{
    public class ReportTests
    {
        private Database _database;

        [SetUp]
        public void Setup()
        {
            _database = Database.Instance;
        }

        [TestCase("Fantasy")]
        public void GetPopularGenre_WhenPopularGenreIsCorrect_ShouldReturnPopularGenre(string expected)
        {
            var books = _database.Books.ToList();
            var genres = _database.Genres.ToList();

            var result = Report.GetPopularGenre(books, genres).Name;

            Assert.AreEqual(result, expected);
        }

        [TestCase("Novel")]
        public void GetPopularGenre_WhenPopularGenreIsNotCorrect_ShouldReturnIncorrectGenre(string expected)
        {
            var books = _database.Books.ToList();
            var genres = _database.Genres.ToList();

            var result = Report.GetPopularGenre(books, genres).Name;

            Assert.AreNotEqual(result, expected);
        }

        [TestCase("Goncharuk Artem Gennadievich")]
        public void GetMostReadingSubscriber_WhenSubscriberIsCorrect_ShouldReturnCorrectSubcriber(string expected)
        {
            var histories = _database.Histories.ToList();
            var subscribers = _database.Subscribers.ToList();

            var result = Report.GetMostReadingSubscriber(histories, subscribers).FullName;

            Assert.AreEqual(result, expected);
        }

        [TestCase("Gatalskiy Renat Alexandrovich")]
        public void GetMostReadingSubscriber_WhenSubscriberIsNotCorrect_ShouldReturnIncorrectSubcriber(string expected)
        {
            var histories = _database.Histories.ToList();
            var subscribers = _database.Subscribers.ToList();

            var result = Report.GetMostReadingSubscriber(histories, subscribers).FullName;

            Assert.AreNotEqual(result, expected);
        }

        [TestCase("Anjey Sapkovskiy")]
        public void GetMostPopularAuthor_WhenAuthorIsCorrect_ShouldReturnCorrectAuthor(string expected)
        {
            var books = _database.Books.ToList();
            var authors = _database.Authors.ToList();

            var result = Report.GetMostPopularAuthor(books, authors).Name
                         + " "
                         + Report.GetMostPopularAuthor(books, authors).Surname;

            Assert.AreEqual(result, expected);
        }
    }
}