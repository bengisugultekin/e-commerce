using System.ComponentModel.DataAnnotations;

namespace E_Ticaret.Entity.Models
{
    public class Product
    {
        public int ProductID { get; set; }

        public int BookID { get; set; }

        [DataType(DataType.ImageUrl)]
        public string PhotoUrl { get; set; }

        public string BookName { get; set; }

        public int BookCount { get; set; }

        [Range(1, 100), DataType(DataType.Currency)]
        public double Price { get; set; }

        [Range(1, 100), DataType(DataType.Currency)]
        public double TotalPrice
        {
            get { return Price * BookCount; }

        }

        public bool Checked { get; set; }

        //mapping?
    }
}
