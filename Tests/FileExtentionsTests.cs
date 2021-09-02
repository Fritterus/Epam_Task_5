using Epam_Task_5.Enums;
using Epam_Task_5.Reports.FileWork;
using FluentAssertions;
using NUnit.Framework;
using System.IO;

namespace Tests
{
    public class FileExtentionsTests
    {
        [Test]
        public void Test_WriteAnyPopularInXlsxFile()
        {
            string filePath = @"..\..\..\..\Epam_Task_5\Resources\Xlsx\AnyPopularList.xlsx";

            int column = 2;

            XlsxFormat.WriteAnyPopularInXlsxFile(filePath, TypeSort.Ascending, column);

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
            string filePath = @"..\..\..\..\Epam_Task_5\Resources\Xlsx\BorrowedBookList.xlsx";

            int column = 2;

            XlsxFormat.WriteBorrowedBooksInXlsxFile(filePath, TypeSort.Ascending, column);

            long result;

            using (var reader = new FileStream(filePath, FileMode.Open))
            {
                result = reader.Length;
            }

            Assert.IsTrue(result != 0);
        }

        [Test]
        public void Test_WriteShabbyBooksInXlsxFile()
        {
            string filePath = @"..\..\..\..\Epam_Task_5\Resources\Xlsx\ShabbyBooksList.xlsx";

            int column = 2;

            XlsxFormat.WriteShabbyBooksInXlsxFile(filePath, TypeSort.Ascending, column);

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
            string filePath = @"..\..\..\..\Epam_Task_5\Resources\Txt\AnyPopularList.txt";

            TxtFormat.WriteAnyPopularInTxtFile(filePath);

            string textFromFile = File.ReadAllText(filePath);

            textFromFile.Should().NotBeEmpty();
        }

        [Test]
        public void Test_WriteBorrowedBooksInTxtFile()
        {
            string filePath = @"..\..\..\..\Epam_Task_5\Resources\Txt\BorrowedBookList.txt";

            TxtFormat.WriteBorrowedBooksInTxtFile(filePath);

            string textFromFile = File.ReadAllText(filePath);

            textFromFile.Should().NotBeEmpty();
        }

        [Test]
        public void Test_WriteShabbyBooksInTxtFile()
        {
            string filePath = @"..\..\..\..\Epam_Task_5\Resources\Txt\ShabbyBooksList.txt";

            TxtFormat.WriteShabbyBooksInTxtFile(filePath);

            string textFromFile = File.ReadAllText(filePath);

            textFromFile.Should().NotBeEmpty();
        }

        [Test]
        public void Test_WriteAnyPopularInPdfFile()
        {
            string directoryPath = @"..\..\..\..\Epam_Task_5\Resources\PDF";
            string filePath = @"..\..\..\..\Epam_Task_5\Resources\PDF\AnyPopularList.pdf";

            PdfFormat.WriteAnyPopularInPdfFile(directoryPath);

            string textFromFile = File.ReadAllText(filePath);

            textFromFile.Should().NotBeEmpty();
        }

        [Test]
        public void Test_WriteBorrowedBooksInPdfFile()
        {
            string directoryPath = @"..\..\..\..\Epam_Task_5\Resources\PDF";
            string filePath = @"..\..\..\..\Epam_Task_5\Resources\PDF\BorrowedBookList.pdf";

            PdfFormat.WriteBorrowedBooksInPdfFile(directoryPath);

            string textFromFile = File.ReadAllText(filePath);

            textFromFile.Should().NotBeEmpty();
        }

        [Test]
        public void Test_WriteShabbyBooksInPdfFile()
        {
            string directoryPath = @"..\..\..\..\Epam_Task_5\Resources\PDF";
            string filePath = @"..\..\..\..\Epam_Task_5\Resources\PDF\ShabbyBooksList.pdf";

            PdfFormat.WriteShabbyBooksInPdfFile(directoryPath);

            string textFromFile = File.ReadAllText(filePath);

            textFromFile.Should().NotBeEmpty();
        }


    }
}