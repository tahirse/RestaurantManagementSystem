using RestaurantManagementSystem.DataAccess.Data;
using RestaurantManagementSystem.Services.Interfaces;


namespace RestaurantManagementSystem.Services.Services
{
    public class MenuItemService:IMenuItemService
    {
        private readonly RestaurantContext _context;
        public MenuItemService()
        {
            _context = new RestaurantContext();
        }
    }
}
