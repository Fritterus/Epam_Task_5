using Epam_Task_5.CRUD;
using Epam_Task_5.Enums;
using Epam_Task_5.Factory;
using Epam_Task_5.ORM;
using Epam_Task_5.ORM.Tables;
using Epam_Task_5.Reports;
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
        public void Test_WritePopularGenreInXlsxFile()
        {
            string filePath = @"..\..\..\..\Epam_Task_5\Resources\AnyPopularList.xlsx";

            int column = 2;

            FileExtentions.WritePopularGenreInXlsxFile(filePath, TypeSort.Ascending, column);

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

    }
}