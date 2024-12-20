

using System.ComponentModel.DataAnnotations;
using System.Threading.Channels;

namespace RestaurantManagementSystem.Core.Entities
{
    public class OrderItem:BaseEntity
    {
        public MenuItem MenuItem { get; set; } 
       
        public int Count { get; set; }

        public int OrderId { get; set; }

        public Order Order { get; set; }
       
        public int MenuItemId { get; set; }

        public override string ToString() => $"OrderId: {OrderId}, MenuItemId: {MenuItemId}, Count: {Count} ";
    }
}
