using Epam_Task_5.Factory;
using Epam_Task_5.ORM.Tables;
using NUnit.Framework;

namespace Tests
{
    public class CustomFactoryTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CreateModel_WhenTypeIsNotAbstract_ShouldReturnCorrectObject()
        {
            Author result = (Author)CustomFactory.CreateModel<Author>();
            Author expected = new Author();

            Assert.AreEqual(result, expected);
        }

        [Test]
        public void CreateModel_WhenTypeIsAbstract_ShouldReturnException()
        {
            Assert.That(() => CustomFactory.CreateModel<BaseEntity>(), Throws.Exception);
        }

        [Test]
        public void CreateModel_WhenModelInThisAssembly_ShouldReturnCorrectObject()
        {
            string modelName = typeof(Author).FullName;
            BaseEntity result = CustomFactory.CreateModel(modelName);
            BaseEntity expected = new Author();

            Assert.AreEqual(result, expected);
        }

        [TestCase("Author", TestName = "CreateModel_WhenModelNameIsNotFull_ShouldReturnException")]
        [TestCase("Order", TestName = "CreateModel_WhenModelIsNotInThisAssembly_ShouldReturnException")]
        public void Test_CreateModel(string fullName)
        {
            Assert.That(() => CustomFactory.CreateModel(fullName), Throws.Exception);
        }
    }
}