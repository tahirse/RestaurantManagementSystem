

using RestaurantManagementSystem.Core.Entities;
using RestaurantManagementSystem.Services.Services;
using System.Security.AccessControl;

namespace RestaurantManagementSystem.App.Controllers
{
    internal class MenuController
    {
       private readonly MenuItemService _menuItemService;

        public MenuController()
        {
            _menuItemService = new MenuItemService();
        }

        public void Create()
        {
            _menuItemService.Create(new() { Price = default, Name = "", Category = "" });
        }

        public void EditMenuItem()
        {
            _menuItemService.EditMenuItem();
        }
        public void AddMenuItem(string name,decimal price,string category)
        {
            _menuItemService.AddMenuItem(name,price,category);
        }
        public void RemoveMenuItem()
        {
            _menuItemService.RemoveMenuItem(5);
        }
        public List<MenuItem> GetMenuItems()
        {
            return _menuItemService.GetMenuItems();
        }
        public List<MenuItem> GetMenuItemsByCategory()
        {
            
            return GetMenuItemsByCategory();  
        }
        public List<MenuItem> GetMenuItemsByPrice(decimal price)
        {
            return GetMenuItemsByPrice(35);
        }
        public List<MenuItem> SearchMenuItems(string search)
        {
            return _menuItemService.SearchMenuItems(search);    
        }

    }
}
