

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
            _menuItemService.EditMenuItem(1, "Soup", 5);
        }
        public void AddMenuItem()
        {
            _menuItemService.AddMenuItem("Bizon",23,"Ickiler");
        }

    }
}
