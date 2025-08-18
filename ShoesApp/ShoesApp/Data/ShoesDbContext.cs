using Microsoft.EntityFrameworkCore;
using ShoesApp.Models;
using System.Security.Cryptography;

namespace ShoesApp.Data
{
    public class ShoesDbContext : DbContext
    {
        public ShoesDbContext(DbContextOptions<ShoesDbContext> options) : base(options)
        {
        }

        public DbSet<Shoe> Shoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            List<Shoe> Shoes = new List<Shoe>
        {
            new Shoe
            {
                Id = 1,
                Brand = "Nike",
                Model = "Air Max 270",
                Category = "Running",
                Color = "Black/White",
                Price = 120.99m,
                Size = 42,
                ImageUrl = "/images/shoes/nike-airmax270.jpg"
            },
            new Shoe
            {
                Id = 2,
                Brand = "Adidas",
                Model = "Ultraboost 21",
                Category = "Running",
                Color = "Core Black",
                Price = 150.50m,
                Size = 43,
                ImageUrl = "/images/shoes/adidas-ultraboost21.jpg"
            },
            new Shoe
            {
                Id = 3,
                Brand = "Puma",
                Model = "RS-X",
                Category = "Casual",
                Color = "White/Blue",
                Price = 95.00m,
                Size = 41,
                ImageUrl = "/images/shoes/puma-rsx.jpg"
            },
            new Shoe
            {
                Id = 4,
                Brand = "Converse",
                Model = "Chuck Taylor All Star",
                Category = "Casual",
                Color = "Red",
                Price = 60.00m,
                Size = 44,
                ImageUrl = "/images/shoes/converse-chucktaylor.jpg"
            },
            new Shoe
            {
                Id = 5,
                Brand = "Clarks",
                Model = "Tilden Cap",
                Category = "Formal",
                Color = "Brown",
                Price = 80.00m,
                Size = 42,
                ImageUrl = "/images/shoes/clarks-tilden.jpg"
            }
        };


            modelBuilder
                .Entity<Shoe>()
                .HasData(Shoes);
        }
    }
}
