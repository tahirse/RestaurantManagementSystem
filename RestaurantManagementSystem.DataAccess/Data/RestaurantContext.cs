using Microsoft.EntityFrameworkCore;

namespace RestaurantManagementSystem.DataAccess.Data
{
    public class RestaurantContext:DbContext
    {



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("");
        }
    }
}
