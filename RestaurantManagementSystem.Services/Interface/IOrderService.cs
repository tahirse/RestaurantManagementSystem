using RestaurantManagementSystem.Core.Entities;

namespace RestaurantManagementSystem.Services.Interface
{
    public interface IOrderService
    {
        void AddOrderItem(int orderNo, int menuItemId, int count);
        Order GetById(int? id);
        void GetOrderByDate();
        void GetOrderByNo();
        List<OrderItem> GetOrderItems();
        Task<List<OrderItem>> GetOrderItemsAsync();
        void GetOrdersByDatesInterval();
        void GetOrdersByPriceInterval();
        void RemoveOrder(int? id);
    }
}