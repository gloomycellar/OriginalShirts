using OriginalShirts.Domain;
using System.Data.Entity;

namespace OriginalShirts.Dal
{
    public class ApplicationContext: DbContext
    {
        public ApplicationContext(): base("DefaultConnection")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Product> Shirts { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Tag> Tags{ get; set; }
        public DbSet<TagGroup> TagsGroups { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<UserDetail> UserDetails { get; set; }
        public DbSet<NpDepartment> NpDepartments { get; set; }


        public static ApplicationContext Create()
        {
            return new ApplicationContext();
        }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Tag>().HasRequired(p => p.).WithMany(f => f.Tags).HasForeignKey(fk => fk.PermissionGroupId);
        //}
    }
}
