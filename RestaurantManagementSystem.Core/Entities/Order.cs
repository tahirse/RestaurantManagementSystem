
namespace RestaurantManagementSystem.Core.Entities
{
    public class Order:BaseEntity
    {        
        public List<OrderItem> OrderItems { get; set; } 
        public decimal TotalAmount { get; set; }   
        public DateTime Date { get; set; }
        public override string ToString() => $"TotalAmount: {TotalAmount}, DateTime: {Date}";
    }
}
