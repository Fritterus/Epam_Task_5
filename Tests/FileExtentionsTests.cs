using Epam_Task_5.CRUD;
using Epam_Task_5.Enums;
using Epam_Task_5.Factory;
using Epam_Task_5.ORM;
using Epam_Task_5.ORM.Tables;
using Epam_Task_5.Reports;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Data.SqlClient;
using System.IO;
using System.Linq;

namespace Tests
{
    public class FileExtentionsTests
    {
        [Test]
        public void Test_WriteAnyPopularInXlsxFile()
        {
            string filePath = @"..\..\..\..\Epam_Task_5\Resources\AnyPopularList.xlsx";

            int column = 2;

            FileExtentions.WriteAnyPopularInXlsxFile(filePath, TypeSort.Ascending, column);

            long result;

            using(var reader = new FileStream(filePath, FileMode.Open))
            {
                result = reader.Length;
            }

            Assert.IsTrue(result != 0);
        }

        [Test]
        public void Test_WriteBorrowedBooksInXlsxFile()
        {
            string filePath = @"..\..\..\..\Epam_Task_5\Resources\BorrowedBookList.xlsx";

            int column = 2;

            FileExtentions.WriteBorrowedBooksInXlsxFile(filePath, TypeSort.Ascending, column);

            long result;

            using (var reader = new FileStream(filePath, FileMode.Open))
            {
                result = reader.Length;
            }

            Assert.IsTrue(result != 0);
        }

        [Test]
        public void Test_WriteAnyPopularInTxtFile()
        {
            string filePath = @"..\..\..\..\Epam_Task_5\Resources\AnyPopularList.txt";

            FileExtentions.WriteAnyPopularInTxtFile(filePath);

            string textFromFile = File.ReadAllText(filePath);

            textFromFile.Should().NotBeEmpty();
        }

        [Test]
        public void Test_WriteBorrowedBooksInTxtFile()
        {
            string filePath = @"..\..\..\..\Epam_Task_5\Resources\BorrowedBookList.txt";

            FileExtentions.WriteBorrowedBooksInTxtFile(filePath);

            string textFromFile = File.ReadAllText(filePath);

            textFromFile.Should().NotBeEmpty();
        }

        [Test]
        public void Test_WriteAnyPopularInPdfFile()
        {
            string directoryPath = @"..\..\..\..\Epam_Task_5\Resources";
            string filePath = @"..\..\..\..\Epam_Task_5\Resources\AnyPopularList.pdf";

            FileExtentions.WriteAnyPopularInPdfFile(directoryPath);

            string textFromFile = File.ReadAllText(filePath);

            textFromFile.Should().NotBeEmpty();
        }

        [Test]
        public void Test_WriteBorrowedBooksInPdfFile()
        {
            string directoryPath = @"..\..\..\..\Epam_Task_5\Resources";
            string filePath = @"..\..\..\..\Epam_Task_5\Resources\BorrowedBookList.pdf";

            FileExtentions.WriteBorrowedBooksInPdfFile(directoryPath);

            string textFromFile = File.ReadAllText(filePath);

            textFromFile.Should().NotBeEmpty();
        }
    }
}