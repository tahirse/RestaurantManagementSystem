
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using RestaurantManagementSystem.Core.Entities;

namespace RestaurantManagementSystem.DataAccess.Configurations
{
    internal class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder) 
        {
            builder.Property(o => o.TotalAmount).IsRequired();       
            builder.HasMany(o => o.OrderItems).WithOne(oi => oi.Order).HasForeignKey(oi => oi.OrderId);
        }
    }
}
