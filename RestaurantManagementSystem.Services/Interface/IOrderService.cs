using RestaurantManagementSystem.Core.Entities;

namespace RestaurantManagementSystem.Services.Interface
{
    public interface IOrderService
    {
        void Create(OrderItem orderItem);
        Task CreateAsync(OrderItem orderItem);
        OrderItem GetById(int? id);
        Task<OrderItem> GetByIdAsync(int? id);
        List<OrderItem> GetOrderItems();
        Task<List<OrderItem>> GetOrderItemsAsync();
    }
}