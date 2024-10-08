using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FirstMVC.Models
{
    public class ShopContext: IdentityDbContext<ApplicationUser>
    {
        public ShopContext():base() { }
        public ShopContext(DbContextOptions option):base(option) { }
        

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }

       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasIndex( p => p.Name).IsUnique(true);

            modelBuilder.Entity<ApplicationUser>()
                .HasOne(a => a.Cart)
                .WithOne(c => c.User)
                .HasForeignKey<Cart>(c => c.UserID); // Configure foreign key

            modelBuilder.Entity<Cart>()
                .HasMany(c => c.Products)
                .WithMany(p => p.Carts)
                .UsingEntity<Dictionary<string, object>>( // No explicit entity required
                "CartProduct", // Name of the join table
                j => j.HasOne<Product>().WithMany().HasForeignKey("ProductId"),
                j => j.HasOne<Cart>().WithMany().HasForeignKey("CartId")
                );

            base.OnModelCreating(modelBuilder);
        }






    }
}
