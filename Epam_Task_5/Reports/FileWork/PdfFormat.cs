using Aspose.Pdf;
using Aspose.Pdf.Text;
using Epam_Task_5.ORM;
using System.IO;
using System.Linq;

namespace Epam_Task_5.Reports.FileWork
{
    public class PdfFormat
    {
        /// <summary>
        /// Method for write any popular in PDF file
        /// </summary>
        /// <param name="filePath"></param>
        public static void WriteAnyPopularInPdfFile(string filePath)
        {
            Database database = Database.Instance;
            var books = database.Books.ToList();
            var genres = database.Genres.ToList();
            var authors = database.Authors.ToList();
            var subscribers = database.Subscribers.ToList();
            var histories = database.Histories.ToList();

            var popularAuthorName = Report.GetMostPopularAuthor(books, authors).Name
                                        + " "
                                        + Report.GetMostPopularAuthor(books, authors).Surname;

            var subscriberFullName = Report.GetMostReadingSubscriber(histories, subscribers).FullName;
            var popularGenreName = Report.GetPopularGenre(books, genres).Name;

            Document document = new Document();
            Page page = document.Pages.Add();

            var table = new Table
            {
                ColumnWidths = "133",
                Border = new BorderInfo(BorderSide.Box, 1f, Color.DarkSlateGray),
                DefaultCellBorder = new BorderInfo(BorderSide.Box, 0.5f, Color.Black),
                DefaultCellPadding = new MarginInfo(4.5, 4.5, 4.5, 4.5),
                Margin =
                {
                    Bottom = 10
                },
                DefaultCellTextState =
                {
                    Font =  FontRepository.FindFont("Helvetica")
                }
            };

            var headerRow = table.Rows.Add();
            headerRow.Cells.Add("Popular author");
            headerRow.Cells.Add("Most reading subscriber");
            headerRow.Cells.Add("Popular genre");

            foreach (Cell headerRowCell in headerRow.Cells)
            {
                headerRowCell.BackgroundColor = Color.Gray;
                headerRowCell.DefaultCellTextState.ForegroundColor = Color.WhiteSmoke;
            }

            var dataRow = table.Rows.Add();
            dataRow.Cells.Add(popularAuthorName);
            dataRow.Cells.Add(subscriberFullName);
            dataRow.Cells.Add(popularGenreName);


            page.Paragraphs.Add(table);

            var outputFileName = Path.Combine(filePath, "AnyPopularList.pdf");

            document.Save(outputFileName);
        }

        /// <summary>
        /// Method for write quantity borrowed books in PDF file
        /// </summary>
        /// <param name="filePath"></param>
        public static void WriteBorrowedBooksInPdfFile(string filePath)
        {
            Database database = Database.Instance;
            var books = database.Books.ToList();
            var histories = database.Histories.ToList();

            var quantityBorrowedBooks = Report.GetQuantityBorrowedBooks(books, histories).Values.ToArray();

            Document document = new Document();
            Page page = document.Pages.Add();

            var table = new Table
            {
                ColumnWidths = "133",
                Border = new BorderInfo(BorderSide.Box, 1f, Color.DarkSlateGray),
                DefaultCellBorder = new BorderInfo(BorderSide.Box, 0.5f, Color.Black),
                DefaultCellPadding = new MarginInfo(4.5, 4.5, 4.5, 4.5),
                Margin =
                {
                    Bottom = 10
                },
                DefaultCellTextState =
                {
                    Font =  FontRepository.FindFont("Helvetica")
                }
            };

            var headerRow = table.Rows.Add();
            headerRow.Cells.Add("Book name");
            headerRow.Cells.Add("Quantity borrowed");

            foreach (Cell headerRowCell in headerRow.Cells)
            {
                headerRowCell.BackgroundColor = Color.Gray;
                headerRowCell.DefaultCellTextState.ForegroundColor = Color.WhiteSmoke;
            }


            for (int i = 0; i < books.Count(); i++)
            {
                var dataRow = table.Rows.Add();

                dataRow.Cells.Add(books[i].Name);
                dataRow.Cells.Add($"{quantityBorrowedBooks[i]}");
            }

            page.Paragraphs.Add(table);

            var outputFileName = Path.Combine(filePath, "BorrowedBookList.pdf");

            document.Save(outputFileName);
        }

        /// <summary>
        /// Method for write shabby books list in PDF file
        /// </summary>
        /// <param name="filePath"></param>
        public static void WriteShabbyBooksInPdfFile(string filePath)
        {
            Database database = Database.Instance;
            var books = database.Books.ToList();
            var histories = database.Histories.ToList();

            var shabbyBooks = Report.GetShabbyBookList(books, histories);

            Document document = new Document();
            Page page = document.Pages.Add();

            var table = new Table
            {
                ColumnWidths = "133",
                Border = new BorderInfo(BorderSide.Box, 1f, Color.DarkSlateGray),
                DefaultCellBorder = new BorderInfo(BorderSide.Box, 0.5f, Color.Black),
                DefaultCellPadding = new MarginInfo(4.5, 4.5, 4.5, 4.5),
                Margin =
                {
                    Bottom = 10
                },
                DefaultCellTextState =
                {
                    Font =  FontRepository.FindFont("Helvetica")
                }
            };

            var headerRow = table.Rows.Add();
            headerRow.Cells.Add("Id");
            headerRow.Cells.Add("Name");

            foreach (Cell headerRowCell in headerRow.Cells)
            {
                headerRowCell.BackgroundColor = Color.Gray;
                headerRowCell.DefaultCellTextState.ForegroundColor = Color.WhiteSmoke;
            }


            for (int i = 0; i < shabbyBooks.Count(); i++)
            {
                var dataRow = table.Rows.Add();

                dataRow.Cells.Add($"{shabbyBooks[i].Id}");
                dataRow.Cells.Add($"{shabbyBooks[i].Name}");
            }

            page.Paragraphs.Add(table);

            var outputFileName = Path.Combine(filePath, "ShabbyBooksList.pdf");

            document.Save(outputFileName);
        }
    }
}
