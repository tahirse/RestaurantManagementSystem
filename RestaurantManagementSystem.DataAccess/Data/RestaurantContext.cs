﻿using Microsoft.EntityFrameworkCore;
using RestaurantManagementSystem.Core.Entities;
using RestaurantManagementSystem.DataAccess.Configurations;

namespace RestaurantManagementSystem.DataAccess.Data
{
    public class RestaurantContext : DbContext
    {
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<OrderItem>OrderItems { get; set; }
        public DbSet<Order>Orders { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=Tahir;Database=RestaurantDb;TrustServerCertificate=True;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MenuItemConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof (OrderConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(OrdeItemConfiguration).Assembly);
        }
    }
}
