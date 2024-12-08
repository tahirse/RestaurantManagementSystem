using RestaurantManagementSystem.DataAccess.Data;
using RestaurantManagementSystem.Services.Interfaces;


namespace RestaurantManagementSystem.Services.Services
{
    public class OrderItemService:IOrderItemService
    {
        private readonly RestaurantContext _context;
        public OrderItemService()
        {
            _context = new RestaurantContext();
        }
    }
}
