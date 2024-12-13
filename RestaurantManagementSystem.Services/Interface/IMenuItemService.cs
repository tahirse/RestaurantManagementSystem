using RestaurantManagementSystem.Core.Entities;

namespace RestaurantManagementSystem.Services.Interface
{
    public interface IMenuItemService
    {
        void AddMenuItem( string name, decimal price, string category);
        Task<MenuItem> AddMenuItemAsync(int? id, string name, decimal price, string category);
        void Create(MenuItem menuItem);
        Task CreateAsync(MenuItem menuItem);
        MenuItem EditMenuItem(int? id, string name, decimal price);
        Task<MenuItem> EditMenuItemAsync(int? id, string name, decimal price);
        MenuItem GetById(int? id);
        Task<MenuItem> GetByIdAsync(int? id);
        List<MenuItem> GetMenuItems();
        Task<List<MenuItem>> GetMenuItemsAsync();
        List<MenuItem> GetMenuItemsByCategory(string category);
        Task<List<MenuItem>> GetMenuItemsByCategoryAsync(string category);
        List<MenuItem> GetMenuItemsByPrice(decimal price);
        Task<List<MenuItem>> GetMenuItemsByPriceAsync(decimal price);
        MenuItem RemoveMenuItem(int? id);
        Task<MenuItem> RemoveMenuItemAsync(int? id);
        List<MenuItem> SearchMenuItems(string search);
        Task<List<MenuItem>> SearchMenuItemsAsync(string search);
    }
}