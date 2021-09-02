using Epam_Task_5.Enums;
using Epam_Task_5.ORM;
using Epam_Task_5.ORM.Tables;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Epam_Task_5.Reports
{
    /// <summary>
    /// Class for work with file
    /// </summary>
    public class FileExtentions
    {
        /// <summary>
        /// Method for write any popular in excel file
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="typeSort"></param>
        /// <param name="sortColumn"></param>
        public static void WriteAnyPopularInXlsxFile(string filePath, TypeSort typeSort, int sortColumn)
        {
            int leftBoard = 1;
            int rightBoard = 3;

            DoesColumnExist(sortColumn, leftBoard, rightBoard);

            Database database = Database.Instance;
            var books = database.Books.ToList();
            var genres = database.Genres.ToList();
            var authors = database.Authors.ToList();
            var subscribers = database.Subscribers.ToList();
            var histories = database.Histories.ToList();

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using ExcelPackage excelPackage = new ExcelPackage();
            ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("GenreReport");

            worksheet.Cells[1, 1].Value = Report.GetMostPopularAuthor(books, authors).Name;
            worksheet.Cells[1, 2].Value = Report.GetMostReadingSubscriber(histories, subscribers).FullName;
            worksheet.Cells[1, 3].Value = Report.GetPopularGenre(books, genres).Name;

            if (typeSort == TypeSort.Ascending)
            {
                worksheet.Cells["A:C"].Sort(sortColumn);
            }
            else
            {
                worksheet.Cells["A:C"].Sort(sortColumn, true);
            }

            MoveRowsDown(worksheet);

            worksheet.Cells[1, 1].Value = "Popular Author";
            worksheet.Cells[1, 2].Value = "Subscriber";
            worksheet.Cells[1, 3].Value = "Popular Genre";

            FileInfo file = new FileInfo(filePath);
            excelPackage.SaveAs(file);
        }

        /// <summary>
        /// Method for write quantity borrowed books in excel file
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="typeSort"></param>
        /// <param name="sortColumn"></param>
        public static void WriteBorrowedBooksInXlsxFile(string filePath, TypeSort typeSort, int sortColumn)
        {
            int leftBoard = 1;
            int rightBoard = 2;

            DoesColumnExist(sortColumn, leftBoard, rightBoard);

            Database database = Database.Instance;
            var books = database.Books.ToList();
            var histories = database.Histories.ToList();

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using ExcelPackage excelPackage = new ExcelPackage();
            ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("GenreReport");

            for (int i = 0; i < books.Count(); i++)
            {
                worksheet.Cells[i + 1, 1].Value = books[i].Name;
                worksheet.Cells[i + 1, 2].Value = Report.GetQuantityBorrowedBooks(books, histories).Values.ToArray()[i];
            }
            

            if (typeSort == TypeSort.Ascending)
            {
                worksheet.Cells["A:C"].Sort(sortColumn);
            }
            else
            {
                worksheet.Cells["A:C"].Sort(sortColumn, true);
            }

            MoveRowsDown(worksheet);

            worksheet.Cells[1, 1].Value = "Book name";
            worksheet.Cells[1, 2].Value = "Quantity borrowed";

            FileInfo file = new FileInfo(filePath);
            excelPackage.SaveAs(file);
        }

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
        /// Method for checking column existence
        /// </summary>
        /// <param name="columntNumber"></param>
        /// <param name="leftBoard"></param>
        /// <param name="rightBoard"></param>
        private static void DoesColumnExist(int columntNumber, int leftBoard, int rightBoard)
        {
            if ((columntNumber < leftBoard) || (columntNumber > rightBoard))
            {
                throw new Exception("Column does not exist");
            }
        }
        
        /// <summary>
        /// Method shif rows in table one row down
        /// </summary>
        /// <param name="worksheet">Table</param>
        private static void MoveRowsDown(ExcelWorksheet worksheet)
        {
            for (int i = worksheet.Dimension.Rows; i > 0; i--)
            {
                for (int j = 1; j <= worksheet.Dimension.Columns; j++)
                {
                    worksheet.Cells[i + 1, j].Value = worksheet.Cells[i, j].Value;
                }
            }
        }
    }
}
