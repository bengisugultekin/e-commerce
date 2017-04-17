using System.Collections.Generic;

namespace E_Ticaret.Entity.Models
{
    public class Category
    {
        public int CategoryID { get; set; }

        public string CategoryName { get; set; }

        public List<Book> Books { get; set; }
    }
}
