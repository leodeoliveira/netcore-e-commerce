using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LeoShop.Models
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ShopCartItem> ShopCartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(new Category { Id = 1, Name = "Cat 1", Description = "A good category" });
            modelBuilder.Entity<Category>().HasData(new Category { Id = 2, Name = "Cat 2", Description = "A good category" });
            modelBuilder.Entity<Category>().HasData(new Category { Id = 3, Name = "Cat 3", Description = "A good category" });

          
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 1,
                Name = "Prod 1",
                ShortDescription = "A good product",
                Price = 12.95,
                CategoryId = 1,
                HasStock = true,
                ImageThumbnailUrl = "https://images.unsplash.com/photo-1583743814966-8936f5b7be1a?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9"
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 2,
                Name = "Prod 2",
                ShortDescription = "A good product",
                Price = 17.15,
                CategoryId = 1,
                HasStock = true,
                ImageThumbnailUrl = "https://images.unsplash.com/photo-1583743814966-8936f5b7be1a?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9"
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 3,
                Name = "Prod 3",
                ShortDescription = "A good product",
                Price = 22.95,
                CategoryId = 2,
                HasStock = true,
                ImageThumbnailUrl = "https://images.unsplash.com/photo-1583743814966-8936f5b7be1a?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9"
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 4,
                Name = "Prod 4",
                ShortDescription = "A good product",
                Price = 27.75,
                CategoryId = 3,
                HasStock = true,
                ImageThumbnailUrl = "https://images.unsplash.com/photo-1583743814966-8936f5b7be1a?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9"
            });
        }
    }
}
