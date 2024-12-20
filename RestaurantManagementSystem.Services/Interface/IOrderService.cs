using RestaurantManagementSystem.Core.Entities;

namespace RestaurantManagementSystem.Services.Interface
{
    public interface IOrderService
    {
        void AddOrderItem(int orderNo, int menuItemId, int count);
        Order GetById(int? id);
        void GetOrderByDate();
        void GetOrderByNo();
        void GetOrdersByDatesInterval();
        void GetOrdersByPriceInterval();
        List<OrderItem> GetOrdes();
        void RemoveOrder(int? id);
    }
}