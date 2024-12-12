

using RestaurantManagementSystem.Core.Entities;

namespace RestaurantManagementSystem.Services.Interfaces
{
    public interface IMenuItemService
    {
        public List<MenuItem> GetMenuItems();
        public Task<List<MenuItem>> GetMenuItemsAsync();
        public void Create(MenuItem menuItem);
        public Task CreateAsync(MenuItem menuItem);
        public MenuItem AddMenuItem(int? id, string name, decimal price, string category);
    }
}
