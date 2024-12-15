using RestaurantManagementSystem.Core.Entities;

namespace RestaurantManagementSystem.Services.Interface
{
    public interface IMenuItemService
    {
        void AddMenuItem( string name, decimal price, string category);
        
        void Create(MenuItem menuItem);
       
        void EditMenuItem(int id, string name, decimal? price);
       
        MenuItem GetById(int? id);
      
        List<MenuItem> GetMenuItems();
       
        List<MenuItem> GetMenuItemsByCategory(string category);
       
        List<MenuItem> GetMenuItemsByPrice(decimal price);
       
        void RemoveMenuItem(int? id);
       
        List<MenuItem> SearchMenuItems(string search);
       
    }
}