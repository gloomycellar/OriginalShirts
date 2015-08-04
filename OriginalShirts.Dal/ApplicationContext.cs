using OriginalShirts.Dal.Models;
using System.Data.Entity;

namespace OriginalShirts.Dal
{
    public class ApplicationContext: DbContext
    {
        public ApplicationContext(): base("DefaultConnection")
        {
            //this.Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Shirt> Shirts { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Tag> Tags{ get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Tag>().HasRequired(p => p.).WithMany(f => f.Tags).HasForeignKey(fk => fk.PermissionGroupId);
        //}
    }
}
