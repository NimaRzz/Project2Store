using Microsoft.EntityFrameworkCore;

namespace Project2Store.ShopUI.Models
{
    public class StoreDbContext:DbContext
    {
        public DbSet<Product> Products { get; set; }
        public StoreDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Category = "Mobile",
                    Name = "Samsung A54",
                    Description = "Ram 8 Hard 254",
                    Price = 12_000_000
                },
                new Product
                {
                    Id = 2,
                    Category = "Mobile",
                    Name = "Samsung A52",
                    Description = "Ram 4 Hard 254",
                    Price = 10_000_000
                },
                new Product
                {
                    Id = 3,
                    Category = "Mobile",
                    Name = "Samsung A50",
                    Description = "Ram 2 Hard 254",
                    Price = 8_000_000
                },
                new Product
                {
                    Id = 4,
                    Category = "Mobile",
                    Name = "Samsung A32",
                    Description = "Ram 2 Hard 54",
                    Price = 5_000_000
                },
                new Product
                {
                    Id = 5,
                    Category = "Laptop",
                    Name = "Asus vivabook515",
                    Description = "ram 18 254gb",
                    Price = 40_000_000
                },
                new Product
                {
                    Id = 6,
                    Category = "Laptop",
                    Name = "Asus vivabook515xf",
                    Description = "ram 32 254gb",
                    Price = 45_000_000
                },
                new Product
                {
                    Id = 7,
                    Category = "Laptop",
                    Name = "Asus vivabook400xf",
                    Description = "ram 32 128gb",
                    Price = 35_000_000
                },
                new Product
                {
                    Id = 8,
                    Category = "PC",
                    Name = "Monitor Apple",
                    Description = "1056 * 1000 HZ",
                    Price = 10_000_000
                },
                new Product
                {
                    Id = 9,
                    Category = "PC",
                    Name = "Monitor Dc",
                    Description = "5056 * 3000 HZ",
                    Price = 20_000_000
                },
                new Product
                {
                    Id = 10,
                    Category = "PC",
                    Name = "Monitor Samsung",
                    Description = "2056 * 3000 HZ",
                    Price = 15_000_000
                }
                );
            base.OnModelCreating(modelBuilder);
        }
    }
}
