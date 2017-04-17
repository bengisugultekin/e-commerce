using E_Ticaret.Entity.Models;
using E_Ticaret.Entity.Models.DbConnection;
using System.Collections.Generic;
using System.Linq;

namespace E_Ticaret.DAL.Repos
{
    public class CategoryRepo
    {
        public static List<Category> GetAllForHome()
        {
            using (ETicaretContext db = new ETicaretContext())
            {
                return db.Category.ToList();
            }
        }

        public static string GetCategoryName(int id)
        {
            using (ETicaretContext db = new ETicaretContext())
            {
                return db.Category.Find(id).CategoryName;
            }
        }


    }



}
