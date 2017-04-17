using System;
using System.Collections.Generic;

namespace E_Ticaret.Entity.Models.ViewModel
{
    public class ViewOrderDetails
    {
        public int CustomID { get; set; }

        public double TotalBill { get; set; }

        public DateTime OrderDate { get; set; }

        public string ShippingAddress { get; set; }

        public List<Product> ShoppingBag { get; set; }



        public int CustomerID { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Phone { get; set; }

    }
}
