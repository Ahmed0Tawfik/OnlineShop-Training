using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FirstMVC.Models
{
    public class ShopContext: IdentityDbContext<ApplicationUser>
    {
        public ShopContext():base() { }
        public ShopContext(DbContextOptions option):base(option) { }
        

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasIndex( p => p.Name).IsUnique(true);


            base.OnModelCreating(modelBuilder);
        }






    }
}
