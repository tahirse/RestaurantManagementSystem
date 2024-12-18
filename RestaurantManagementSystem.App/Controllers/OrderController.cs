

using Microsoft.EntityFrameworkCore;
using RestaurantManagementSystem.Core.Entities;
using RestaurantManagementSystem.Services.Services;

namespace RestaurantManagementSystem.App.Controllers
{
    public class OrderController
    {
        private readonly OrderService _orderService;
        public OrderController()
        {
            _orderService = new OrderService();
        }
        public void GetOrdersByDatesInterval()
        {
            _orderService.GetOrdersByDatesInterval();
        }
        public void GetOrderByDate()
        {
            _orderService.GetOrderByDate();
        }
        public void GetOrdersByPriceInterval()
        {
            _orderService.GetOrdersByPriceInterval();
        }
        public void AddOrderItem()
        {
            _orderService.AddOrderItem(1,2,2);
        }

        public void RemoveOrder()
        {
            _orderService.RemoveOrder(4);
        }
        public void GetOrderByNo()
        {
            _orderService.GetOrderByNo();
        }
        public List<OrderItem> GetOrderItems()
        {
            return _orderService.GetOrderItems();
        }
    }
}