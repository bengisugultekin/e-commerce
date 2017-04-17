using E_Ticaret.Entity.Models.DbConnection;

namespace E_Ticaret.DAL.Repos
{
    public class WriterRepo
    {
        public static string GetWriterName(int id)
        {
            using (ETicaretContext db = new ETicaretContext())
            {
                return db.Writer.Find(id).WriterName;
            }
        }
    }
}
