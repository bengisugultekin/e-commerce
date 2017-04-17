namespace E_Ticaret.Entity.Models
{
    public class Book
    {
        public int BookID { get; set; }

        public string BookName { get; set; }

        public string BookSubject { get; set; }

        public string Publisher { get; set; }

        public int WriterID { get; set; }

        public double Price { get; set; }

        public int CategoryID { get; set; }

        public string PhotoUrl { get; set; }


        //Mapping
        public Writer Writer { get; set; }
        public Category Category { get; set; }
    }
}

