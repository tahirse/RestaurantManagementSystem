

using RestaurantManagementSystem.Core.Entities;
using RestaurantManagementSystem.Services.Services;

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
            _menuItemService.Create(new(){  Name = "Soup", Category = "Desert" });
        }

        public void EditMenuIte()
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
            _menuItemService.AddMenuItem("Bizon",23,"Ickiler");
        }


        public void RemoveMenuItem()
        {
            _menuItemService.RemoveMenuItem(1);
        }

    }
}
