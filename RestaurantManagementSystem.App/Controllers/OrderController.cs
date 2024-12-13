

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


        public void Create()
        {
            _orderService.Create(new() {  Count = 10, });
        }
    }
}