using RestaurantManagementSystem.Core.Entities;

namespace RestaurantManagementSystem.Services.Interface
{
    public interface IMenuItemService
    {
        void AddMenuItem();
        void Create(MenuItem menuItem);
        void EditMenuItem(int id, string name, decimal? price);
        MenuItem GetById(int? id);
        List<MenuItem> GetMenuItems();
        Task<List<MenuItem>> GetMenuItemsAsync();
        List<MenuItem> GetMenuItemsByCategory(string category);
        Task<List<MenuItem>> GetMenuItemsByCategoryAsync(string category);
        List<MenuItem> GetMenuItemsByPrice(decimal price);
        void RemoveMenuItem(int? id);
        List<MenuItem> SearchMenuItems(string search);
    }
}