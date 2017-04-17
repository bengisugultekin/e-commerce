using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace E_Ticaret.Entity.Models
{
    public class Custom
    {
        public int CustomID { get; set; }

        public List<Product> ShoppingBag { get; set; }

        [Range(1, 100), DataType(DataType.Currency)]
        public double TotalBill { get; set; }

        public int CustomerID { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-mm-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime OrderDate { get; set; }

        public string ShippingAddress { get; set; }

        public Customer Customer { get; set; }
    }
}
