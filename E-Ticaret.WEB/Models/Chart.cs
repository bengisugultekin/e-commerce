using E_Ticaret.Entity.Models;
using System.Collections.Generic;

namespace E_Ticaret.WEB.Models
{
    public class Chart
    {
        public static List<Product> ShoppingList = new List<Product>();
        public static double Total { get; set; }
    }
}