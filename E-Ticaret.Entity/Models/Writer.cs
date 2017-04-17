using System.Collections.Generic;

namespace E_Ticaret.Entity.Models
{
    public class Writer
    {
        public int WriterID { get; set; }

        public string WriterName { get; set; }

        public List<Book> Books { get; set; }
    }
}
