namespace E_Ticaret.Entity.Models.ViewModel
{
    public class ViewBookForCategory
    {
        public int CategoryID { get; set; }

        public string CategoryName { get; set; }

        public int BookID { get; set; }

        public string BookName { get; set; }

        public string Publisher { get; set; }

        public int WriterID { get; set; }

        public string WriterName { get; set; }

        public double Price { get; set; }

        public string PhotoUrl { get; set; }
    }
}
