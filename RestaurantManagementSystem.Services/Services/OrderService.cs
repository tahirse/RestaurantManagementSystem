using RestaurantManagementSystem.DataAccess.Data;
using RestaurantManagementSystem.Services.Interfaces;


namespace RestaurantManagementSystem.Services.Services
{
    public class OrderService:IOrderService
    {
        private readonly RestaurantContext _context;
        public OrderService()
        {
            _context = new RestaurantContext();
        }
    }
}
