using E_Ticaret.DAL.Repos;
using E_Ticaret.Entity.Models;
using System.Web.Mvc;

namespace E_Ticaret.WEB.Controllers
{
    public class CustomerController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Customer customer)
        {
            var result = CustomerRepo.CheckCustomer(customer);

            if (result != null)
            {
                Session["email"] = customer.Email;
                Session["Customer"] = result;

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Message = "Hata";
                return View();
            }
        }

        // GET: Customer
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Customer customer)
        {
            if (ModelState.IsValid)
            {
                string validationMessage = CustomerRepo.AddCustomer(customer);
                if (validationMessage == "Success")
                {
                    Session["email"] = customer.Email;
                    Session["Customer"] = customer;

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.ValidationMessage = validationMessage;
                    return View(customer);
                }
            }
            else
            {
                return View(customer);
            }


        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Account(Customer newCustomer, int? id)
        {
            if (id != null)
            {
                return View(CustomerRepo.Get((int)id));
            }
            else
            {
                if (newCustomer.CustomerID == 0)
                {
                    var customer = Session["Customer"] as Customer;
                    return View(customer);
                }
                else
                {
                    return View(newCustomer);
                }
            }
        }

        [HttpPost]
        public ActionResult UpdatePassword(string newPassword, string newPassword2, Customer customer)
        {

            var toBeUpdated = CustomerRepo.CheckCustomer(customer);

            if (toBeUpdated != null)
            {
                if (newPassword == newPassword2)
                {
                    var updatedCustomer = CustomerRepo.UpdateCustomerPassword(toBeUpdated, newPassword);
                    return RedirectToAction("Account", "Customer", updatedCustomer);
                }
                else
                {
                    ViewBag.Error = "Hatalı şifre girdiniz.";
                    return RedirectToAction("Account", "Customer", customer);
                }
            }
            else
            {
                ViewBag.Error = "Hatalı şifre girdiniz.";
                return RedirectToAction("Account", "Customer");
            }


        }

        [HttpPost]
        public ActionResult UpdateInfo(Customer customer)
        {

            var updatedCustomer = CustomerRepo.UpdateCustomerInfo(customer);
            return RedirectToAction("Account", "Customer", updatedCustomer);

        }

        public ActionResult Orders(int id)
        {
            ViewBag.ID = id;
            var r = CustomerRepo.GetOrders(id);
            return View(r);
        }

        public ActionResult OrderDetail(int id)
        {
            return View(CustomRepo.GetOrderDetails(id));
        }
    }
}