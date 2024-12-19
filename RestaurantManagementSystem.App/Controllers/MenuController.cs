

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
            _menuItemService.Create(new() { Price = 5, Name = "Dolma", Category = "Yemek" });
        }

        public void EditMenuItem()
        {
            foreach (var item in _menuItemService.GetMenuItems())
            {
                Console.WriteLine($"Id:{item.Id}\nName:{item.Name}\nPrice:{item.Price}");
                Console.WriteLine("=================");
            }
            Console.WriteLine();
            Console.Write("Id:");
            int id=int.Parse(Console.ReadLine());

            _menuItemService.EditMenuItem(id, "Hell", 35m);
        }
        public void AddMenuItem()
        {
            _menuItemService.AddMenuItem();
        }


        public void RemoveMenuItem()
        {
            _menuItemService.RemoveMenuItem(1);
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
