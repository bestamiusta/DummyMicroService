﻿using Microsoft.EntityFrameworkCore;
using ProductMicroService.Model;

namespace ProductMicroService.DbContexts
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions options) : base(options)
        {
        }


        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(

                new Category
                {
                    Id = 1,
                    Name = "Electronics",
                    Description = "Electronic items"
                },
                new Category
                {
                    Id = 2,
                    Name = "Clothes",
                    Description = "Dresses"
                },
                new Category
                {
                    Id = 3,
                    Name = "Grocery",
                    Description = "Grocery items"
                }

                );
        }
    }
}
