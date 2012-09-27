using System.Data.Entity;

namespace MvcApplication1.Models
{
    public class PersonDb : DbContext
    {
        public DbSet<Person> MvcApplication1 { get; set; }
    }
}