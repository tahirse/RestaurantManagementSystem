using RestaurantManagementSystem.Core.Entities;

namespace RestaurantManagementSystem.Services.Interface
{
    public interface IOrderService
    {
        void Create(OrderItem orderItem);
        
        Order GetById(int? id);
        List<OrderItem> GetOrderItems();
        public void AddOrderItem();


    }
}