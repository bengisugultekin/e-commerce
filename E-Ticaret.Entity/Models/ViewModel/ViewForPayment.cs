using System.Collections.Generic;

namespace E_Ticaret.Entity.Models.ViewModel
{
    public class ViewForPayment
    {
        public int CustomerID { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public List<Product> ShoppingList { get; set; }
    }
}
