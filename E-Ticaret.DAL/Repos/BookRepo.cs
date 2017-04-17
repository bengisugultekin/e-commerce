using E_Ticaret.Entity.Models.DbConnection;
using E_Ticaret.Entity.Models.ViewModel;
using System.Collections.Generic;
using System.Linq;

namespace E_Ticaret.DAL.Repos
{
    public class BookRepo
    {
        public static List<ViewForHome> GetAllForHome()
        {
            using (ETicaretContext db = new ETicaretContext())
            {
                return db.Book.Select(b => new ViewForHome
                {
                    BookID = b.BookID,
                    BookName = b.BookName,
                    Price = b.Price,
                    PhotoUrl = b.PhotoUrl,
                    Publisher = b.Publisher,
                    WriterID = b.WriterID,
                    WriterName = b.Writer.WriterName,
                    CategoryID = b.CategoryID,
                    CategoryName = b.Category.CategoryName,

                })
                .OrderByDescending(b => b.BookID)
                .ToList();
            }
        }

        public static List<ViewForHome> Search(string search)
        {
            using (ETicaretContext db = new ETicaretContext())
            {
                return db.Book.Select(b => new ViewForHome
                {
                    BookID = b.BookID,
                    BookName = b.BookName,
                    Price = b.Price,
                    PhotoUrl = b.PhotoUrl,
                    Publisher = b.Publisher,
                    WriterID = b.WriterID,
                    WriterName = b.Writer.WriterName,
                    CategoryID = b.CategoryID,
                    CategoryName = b.Category.CategoryName,

                })
                .Where(b => b.BookName.Contains(search) || b.CategoryName.Contains(search) || b.WriterName.Contains(search))
                .ToList();

            }
        }

        public static ViewBookForDetails GetForDetails(int id)
        {
            using (ETicaretContext db = new ETicaretContext())
            {
                return db.Book
                    .Where(b => b.BookID == id)
                    .Select(b => new ViewBookForDetails
                    {
                        BookID = b.BookID,
                        BookName = b.BookName,
                        BookSubject = b.BookSubject,
                        Publisher = b.Publisher,
                        Price = b.Price,
                        PhotoUrl = b.PhotoUrl,
                        WriterID = b.WriterID,
                        WriterName = b.Writer.WriterName,
                        CategoryID = b.CategoryID,
                        CategoryName = b.Category.CategoryName

                    }).FirstOrDefault();
            }
        }

        public static List<ViewBookForCategory> GetAllBooksByCategory(int id)
        {
            using (ETicaretContext db = new ETicaretContext())
            {
                return db.Book
                    .Where(b => b.CategoryID == id)
                    .Select(b => new ViewBookForCategory
                    {
                        BookID = b.BookID,
                        BookName = b.BookName,
                        PhotoUrl = b.PhotoUrl,
                        Publisher = b.Publisher,
                        Price = b.Price,
                        CategoryID = b.CategoryID,
                        CategoryName = b.Category.CategoryName,
                        WriterID = b.WriterID,
                        WriterName = b.Writer.WriterName,
                    }).ToList();
            }
        }

        public static List<ViewForHome> GetAllBooksByWriter(int id)
        {
            using (ETicaretContext db = new ETicaretContext())
            {
                return db.Book
                    .Where(b => b.WriterID == id)
                    .Select(b => new ViewForHome
                    {
                        BookID = b.BookID,
                        BookName = b.BookName,
                        PhotoUrl = b.PhotoUrl,
                        Publisher = b.Publisher,
                        Price = b.Price,
                        WriterID = b.WriterID,
                        WriterName = b.Writer.WriterName,
                    }).ToList();
            }
        }

        public static ViewForHome GetBookForShoppingBag(int id)
        {
            using (ETicaretContext db = new ETicaretContext())
            {
                return db.Book
                    .Where(b => b.BookID == id)
                    .Select(b => new ViewForHome
                    {
                        BookID = b.BookID,
                        BookName = b.BookName,
                        Price = b.Price,
                        PhotoUrl = b.PhotoUrl,
                        WriterID = b.WriterID,
                        WriterName = b.Writer.WriterName

                    }).FirstOrDefault();
            }
        }


    }
}
