namespace E_Ticaret.Entity.Models.DbConnection
{
    using System.Data.Entity;

    public class ETicaretContext : DbContext
    {

        public ETicaretContext()
            : base("name=ETicaretDB")
        {
        }

        public virtual DbSet<Book> Book { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Custom> Custom { get; set; }
        public virtual DbSet<Writer> Writer { get; set; }
        public virtual DbSet<Category> Category { get; set; }

        public virtual DbSet<Product> Product { get; set; }

    }


}