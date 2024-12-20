using RestaurantManagementSystem.Core.Entities;

namespace RestaurantManagementSystem.Services.Interface
{
    public interface IMenuItemService
    {
        void AddMenuItem(string name, decimal price, string category);
        void Create(MenuItem menuItem);
        void EditMenuItem();
        MenuItem GetById(int? id);
        List<MenuItem> GetMenuItems();
        Task<List<MenuItem>> GetMenuItemsAsync();
        List<MenuItem> GetMenuItemsByCategory();
        Task<List<MenuItem>> GetMenuItemsByCategoryAsync(string category);
        List<MenuItem> GetMenuItemsByPrice(decimal price);
        void RemoveMenuItem(int? id);
        List<MenuItem> SearchMenuItems(string search);
    }
}