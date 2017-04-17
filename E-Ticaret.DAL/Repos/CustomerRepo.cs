using E_Ticaret.Entity.Models;
using E_Ticaret.Entity.Models.DbConnection;
using System.Collections.Generic;
using System.Linq;

namespace E_Ticaret.DAL.Repos
{
    public class CustomerRepo
    {
        public static string AddCustomer(Customer customer)
        {
            using (ETicaretContext db = new ETicaretContext())
            {
                var isThereCustomer = db.Customer.SingleOrDefault(c => c.Email == customer.Email);

                if (isThereCustomer != null)
                {
                    return "Girdiğiniz e-posta adresi zaten kullanılıyor.";
                }
                else
                {
                    db.Customer.Add(customer);
                    db.SaveChanges();
                    return "Success";
                }

            }
        }

        public static Customer CheckCustomer(Customer customer)
        {
            using (ETicaretContext db = new ETicaretContext())
            {
                return db.Customer
                    .Include("CustomList")
                    .Where(c => c.Email.Equals(customer.Email) && c.Password.Equals(customer.Password))
                    .FirstOrDefault();
            }
        }

        public static Customer UpdateCustomerPassword(Customer customer, string newPassword)
        {
            using (ETicaretContext db = new ETicaretContext())
            {
                var toBeUpdated = db.Customer.Find(customer.CustomerID);
                toBeUpdated.Password = newPassword;

                db.SaveChanges();

                return toBeUpdated;
            }
        }

        public static Customer UpdateCustomerInfo(Customer customer)
        {
            using (ETicaretContext db = new ETicaretContext())
            {
                var toBeUpdated = db.Customer.Find(customer.CustomerID);

                toBeUpdated.Name = customer.Name;
                toBeUpdated.Surname = customer.Surname;
                toBeUpdated.Phone = customer.Phone;
                toBeUpdated.Address = customer.Address;

                db.SaveChanges();
                return toBeUpdated;

            }
        }

        public static List<Custom> GetOrders(int id)
        {
            using (ETicaretContext db = new ETicaretContext())
            {
                return db.Customer
                            .Include("CustomList")
                                    .FirstOrDefault(c => c.CustomerID == id)
                                        .CustomList.OrderByDescending(c => c.OrderDate)
                                            .ToList();
            }

        }

        public static Customer Get(int id)
        {
            using (ETicaretContext db = new ETicaretContext())
            {
                return db.Customer.Find(id);

            }
        }

        public static Customer UpdateCustomerAddress(Customer customer)
        {
            using (ETicaretContext db = new ETicaretContext())
            {
                var toBeUpdated = db.Customer.Find(customer.CustomerID);

                toBeUpdated.Address = customer.Address;

                db.SaveChanges();

                return toBeUpdated;

            }
        }




    }
}
