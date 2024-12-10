

using System.ComponentModel.DataAnnotations;

namespace RestaurantManagementSystem.Core.Entities
{
    public class OrderItem:BaseEntity
    {
       
        public MenuItem MenuItem { get; set; } 
       
        public int Count { get; set; }
    }
}
