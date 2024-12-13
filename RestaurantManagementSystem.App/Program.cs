using RestaurantManagementSystem.App.Controllers;

namespace RestaurantManagementSystem.App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //OrderController orderController = new OrderController();
            //orderController.Create();
            MenuController menuController = new MenuController();
           //menuController.Create();
            menuController.AddMenuItem();
        }
    }
}
