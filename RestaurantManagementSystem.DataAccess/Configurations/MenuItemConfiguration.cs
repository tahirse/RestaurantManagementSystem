using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using RestaurantManagementSystem.Core.Entities;
namespace RestaurantManagementSystem.DataAccess.Configurations
{
    internal class MenuItemConfiguration : IEntityTypeConfiguration<MenuItem>
    {
        public void Configure(EntityTypeBuilder<MenuItem> builder) 
        {
            builder.Property(m => m.Name).IsRequired(true).HasMaxLength(20);
            builder.Property(m => m.Category).IsRequired(true).HasMaxLength(30);
            builder.Property(m => m.Price).IsRequired(true);
            builder.HasIndex(m => m.Name).IsUnique();


        }
    }
}
