using E_Ticaret.Entity.Models;
using E_Ticaret.Entity.Models.DbConnection;
using E_Ticaret.Entity.Models.ViewModel;
using System.Linq;

namespace E_Ticaret.DAL.Repos
{
    public class CustomRepo
    {
        public static void Add(Custom custom)
        {
            using (ETicaretContext db = new ETicaretContext())
            {
                db.Custom.Add(custom);
                db.SaveChanges();
            }
        }

        public static ViewOrderDetails GetOrderDetails(int id)
        {
            using (ETicaretContext db = new ETicaretContext())
            {
                return db.Custom.Include("ShoppingBag")
                            .Where(c => c.CustomID == id)
                            .Select(c => new ViewOrderDetails
                            {
                                CustomID = id,
                                TotalBill = c.TotalBill,
                                OrderDate = c.OrderDate,
                                ShippingAddress = c.ShippingAddress,
                                ShoppingBag = c.ShoppingBag,

                                CustomerID = c.CustomerID,
                                Name = c.Customer.Name,
                                Surname = c.Customer.Surname,
                                Phone = c.Customer.Phone,

                            }).FirstOrDefault();

            }
        }

    }
}