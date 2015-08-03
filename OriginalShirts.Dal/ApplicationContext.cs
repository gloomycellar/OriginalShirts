using OriginalShirts.Dal.Models;
using System.Data.Entity;

namespace OriginalShirts.Dal
{
    public class ApplicationContext: DbContext
    {
        public ApplicationContext(): base("DefaultConnection")
        {

        }

        public DbSet<Shirt> Shirts { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Tag> Tags{ get; set; }
    }
}
