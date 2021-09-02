using Epam_Task_5.CRUD;
using Epam_Task_5.Factory;
using Epam_Task_5.ORM.Tables;
using NUnit.Framework;
using System;
using System.Data.SqlClient;

namespace Tests
{
    public class BaseMethodsTests
    {
        private SqlConnection _sqlConnection;

        [SetUp]
        public void Setup()
        {
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Db_Task_5;Integrated Security=True";
            _sqlConnection = new SqlConnection(connectionString);
        }

        [Test]
        public void Create_WhenObjectDoesNotExist_ShouldAddObject()
        {
            BaseMethods<Author> baseMethods = new BaseMethods<Author>(_sqlConnection);
            var author = new Author()
            {
                Id = 7,
                Name = "Jerom",
                Surname = "Selinjer",
                Patronymic = "Nikolayevich"
            };

            baseMethods.Create(author);

            Author result = baseMethods.Read(author.Id);
            baseMethods.Delete(author.Id);

            Assert.AreEqual(result, author);
        }

        [TestCase(2, 1, 3, TestName = "Create_WhenObjectAlreadyExists_ShouldReturnException")]
        [TestCase(7, 3, 9, TestName = "Create_WhenAnyForeignKeyDontExist_ShouldReturnException")]
        public void Test_Create(int id, int firstForeignKey, int secondForeignKey)
        {
            BaseMethods<Book> baseMethods = new BaseMethods<Book>(_sqlConnection);
            var book = new Book()
            {
                Id = id,
                Name = "Small prince",
                AuthorId = firstForeignKey,
                GenreId = secondForeignKey
            };

            Assert.That(() => baseMethods.Create(book), Throws.Exception);
        }

        [Test]
        public void Create_WhenTypeIsAbstract_ShouldReturnException()
        {
            BaseMethods<BaseEntity> baseMethods = new BaseMethods<BaseEntity>(_sqlConnection);
            var book = new Book()
            {
                Id = 9,
                Name = "Small prince",
                AuthorId = 2,
                GenreId = 3
            };

            Assert.That(() => baseMethods.Create(book), Throws.Exception);
        }

        [Test]
        public void Test_Update()
        {
            BaseMethods<Author> baseMethods = new BaseMethods<Author>(_sqlConnection);
            var author = new Author()
            {
                Id = 3,
                Name = "Daddy",
                Surname = "Smash",
                Patronymic = "Smith"
            };

            baseMethods.Update(author.Id, author);
            Author result = baseMethods.Read(author.Id);

            Assert.AreEqual(result, author);
        }

        [Test]
        public void Update_WhenTypeIsAbstract_ShouldReturnException()
        {
            BaseMethods<BaseEntity> baseMethods = new BaseMethods<BaseEntity>(_sqlConnection);
            var expected = new Author()
            {
                Id = 3,
                Name = "Daddy",
                Surname = "Smash",
                Patronymic = "Smith"
            };

            Assert.That(() => baseMethods.Update(expected.Id, expected), Throws.Exception);
        }

        [Test]
        public void Delete_WhenObjectExists_ShouldDeleteObject()
        {
            BaseMethods<Book> baseMethods = new BaseMethods<Book>(_sqlConnection);
            var book = new Book()
            {
                Id = 12,
                Name = "Wild hunt",
                AuthorId = 3,
                GenreId = 2
            };

            baseMethods.Create(book);

            baseMethods.Delete(book.Id);

            Book result = baseMethods.Read(book.Id);

            Assert.IsNull(result);
        }

        [Test]
        public void Delete_WhenTypeIsAbstract_ShouldReturnException()
        {
            BaseMethods<BaseEntity> baseMethods = new BaseMethods<BaseEntity>(_sqlConnection);
            int id = 5;

            Assert.That(() => baseMethods.Delete(id), Throws.Exception);
        }

        [Test]
        public void Read_WhenObjectExists_ShouldReturnCorrectObject()
        {
            BaseMethods<Book> crud = new BaseMethods<Book>(_sqlConnection);
            var expected = new Book()
            {
                Id = 1,
                Name = "War and Piece",
                GenreId = 2,
                AuthorId = 1
            };

            var result = crud.Read(expected.Id);

            Assert.AreEqual(result, expected);
        }

        [TestCase(-100)]
        [TestCase(100)]
        public void Read_WhenObjectNotExists_ShouldReturnNull(int id)
        {
            BaseMethods<Book> crud = new BaseMethods<Book>(_sqlConnection);

            Book result = crud.Read(id);

            Assert.IsNull(result);
        }

        [Test]
        public void Read_WhenTypeIsAbstract_ShouldReturnException()
        {
            BaseMethods<BaseEntity> crud = new BaseMethods<BaseEntity>(_sqlConnection);
            int id = 5;

            Assert.That(() => crud.Read(id), Throws.Exception);
        }
    }
}