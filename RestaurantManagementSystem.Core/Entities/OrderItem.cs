

namespace RestaurantManagementSystem.Core.Entities
{
    public class OrderItem
    {
        public MenuItem MenuItem { get; set; } // The menu item being ordered
        public int Count { get; set; }
    }
}
