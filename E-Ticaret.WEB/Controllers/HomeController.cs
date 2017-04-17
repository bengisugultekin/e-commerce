using E_Ticaret.DAL.Repos;
using E_Ticaret.Entity.Models;
using E_Ticaret.Entity.Models.ViewModel;
using E_Ticaret.WEB.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace E_Ticaret.WEB.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index(int? page)
        {
            ViewBag.Categories = CategoryRepo.GetAllForHome();
            return View(BookRepo.GetAllForHome().ToPagedList(page ?? 1, 8));
        }

        public ActionResult Search(int? page)
        {
            var search = Session["search"];
            var result = BookRepo.Search(search.ToString());
            return View(result.ToPagedList(page ?? 1, 5));
        }

        [HttpPost]
        public ActionResult Search(string search, int? page)
        {
            var result = BookRepo.Search(search);
            Session["search"] = search;
            ViewBag.Search = search;
            return View(result.ToPagedList(page ?? 1, 5));
        }


        public ActionResult BookDetails(int id)
        {
            return View(BookRepo.GetForDetails(id));
        }

        public ActionResult Category(int id, int? page)
        {
            ViewBag.Category = CategoryRepo.GetAllForHome();
            ViewBag.CategoryName = CategoryRepo.GetCategoryName(id);
            return View(BookRepo.GetAllBooksByCategory(id).ToPagedList(page ?? 1, 8));
        }

        public ActionResult Writer(int id)
        {
            ViewBag.WriterName = WriterRepo.GetWriterName(id);
            return View(BookRepo.GetAllBooksByWriter(id));
        }



        [HttpPost]
        public ActionResult BookDetails(ViewBookForDetails model, int BookCount)
        {
            if (Chart.ShoppingList.Count == 0)
            {
                Product p = new Product()
                {
                    BookID = model.BookID,
                    BookName = model.BookName,
                    BookCount = BookCount,
                    Price = model.Price,
                    PhotoUrl = model.PhotoUrl
                };

                Chart.ShoppingList.Add(p);
                return RedirectToAction("ShoppingChart", "Home", Chart.ShoppingList);
            }
            else
            {
                foreach (var item in Chart.ShoppingList)
                {
                    if (item.BookID == model.BookID)
                    {
                        item.BookCount += BookCount;
                        ViewBag.Liste = Chart.ShoppingList;
                        return RedirectToAction("ShoppingChart", "Home", Chart.ShoppingList);
                    }
                }

                Product p = new Product()
                {
                    BookID = model.BookID,
                    BookName = model.BookName,
                    BookCount = BookCount,
                    Price = model.Price,
                    PhotoUrl = model.PhotoUrl
                };
                Chart.ShoppingList.Add(p);
                return RedirectToAction("ShoppingChart", "Home", Chart.ShoppingList);

            }

        }

        public ActionResult ShoppingChart(int? id)
        {
            if (id.HasValue)
            {
                var model = BookRepo.GetBookForShoppingBag((int)id);

                if (Chart.ShoppingList.Count == 0)
                {
                    Product p = new Product()
                    {
                        BookID = model.BookID,
                        BookName = model.BookName,
                        BookCount = 1,
                        Price = model.Price,
                        PhotoUrl = model.PhotoUrl
                    };
                    Chart.ShoppingList.Add(p);
                    return View(Chart.ShoppingList);
                }
                else
                {
                    foreach (var item in Chart.ShoppingList)
                    {
                        if (item.BookID == model.BookID)
                        {
                            item.BookCount++;
                            ViewBag.Liste = Chart.ShoppingList;
                            return View(Chart.ShoppingList);
                        }
                    }

                    Product p = new Product()
                    {
                        BookID = model.BookID,
                        BookName = model.BookName,
                        BookCount = 1,
                        Price = model.Price,
                        PhotoUrl = model.PhotoUrl
                    };
                    Chart.ShoppingList.Add(p);
                    return View(Chart.ShoppingList);

                }

            }
            else
            {
                if (Chart.ShoppingList.Count == 0)
                {
                    return View();
                }
                else
                {
                    return View(Chart.ShoppingList);
                }
            }

        }

        public ActionResult Payment()
        {
            if (Session["email"] != null)
            {
                var logedCustomer = Session["Customer"] as Customer;

                ViewForPayment model = new ViewForPayment()
                {
                    Address = logedCustomer.Address,
                    Phone = logedCustomer.Phone,
                    ShoppingList = Chart.ShoppingList
                };

                return View(model);
            }
            else
            {
                return RedirectToAction("Login", "Customer");
            }

        }

        [HttpPost]
        public ActionResult Payment(decimal Total)
        {
            Custom custom = new Custom();
            custom.TotalBill = (double)Total;
            custom.ShoppingBag = Chart.ShoppingList;
            custom.OrderDate = DateTime.Now;


            var logedCustomer = Session["Customer"] as Customer;

            custom.CustomerID = logedCustomer.CustomerID;
            custom.ShippingAddress = logedCustomer.Address;

            CustomRepo.Add(custom);

            Chart.ShoppingList.Clear();

            return RedirectToAction("CompletedOrder", "Home", custom);
        }


        public ActionResult CompletedOrder(Custom custom)
        {
            var viewOrderDetailsModel = CustomRepo.GetOrderDetails(custom.CustomID);
            return View(viewOrderDetailsModel);
        }



        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Delete(List<Product> list)
        {

            foreach (var item in list.ToArray())
            {
                if (item.Checked == true)
                {
                    list.Remove(item);
                }
            }
            Chart.ShoppingList = list;
            return RedirectToAction("ShoppingChart", "Home", Chart.ShoppingList);
        }

        public ActionResult Update(string shippingAddress)
        {

            var logedCustomer = Session["Customer"] as Customer;
            logedCustomer.Address = shippingAddress;
            var updated = CustomerRepo.UpdateCustomerAddress(logedCustomer);

            ViewForPayment model = new ViewForPayment()
            {
                Address = updated.Address,
                Phone = updated.Phone,
                ShoppingList = Chart.ShoppingList
            };

            return RedirectToAction("Payment", "Home", model);
        }
    }
}





//if (Session["email"] != null)
//{

//}
//else
//{
//    return RedirectToAction("Login", "Customer");
//}