using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestaurantManagementSystem.Core.Entities;


namespace RestaurantManagementSystem.DataAccess.Configurations
{
    internal class OrdeItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.Property(o => o.Count).IsRequired(true);
            builder.HasOne(o => o.MenuItem).WithOne(m => m.OrderItem).HasForeignKey<OrderItem>(o => o.MenuItemId);
        }
    }
}