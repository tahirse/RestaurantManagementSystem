using RestaurantManagementSystem.App.Controllers;
using RestaurantManagementSystem.Core.Entities;

namespace RestaurantManagementSystem.App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            OrderController orderController = new OrderController();
            //orderController.Create();
            MenuController menuController = new MenuController();
            //menuController.Create();
            //menuController.AddMenuItem();
            //menuController.EditMenuIte();
            // menuController.Create();
            //menuController.RemoveMenuItem();
            //orderController.RemoveOrder();
            //orderController.GetOrderByNo();
            //orderController.AddOrderItem();
            // Console.WriteLine( orderController.GetOrderItems());
            //orderController.GetOrdersByDatesInterval();
            //orderController.GetOrderByDate();
            orderController.GetOrdersByPriceInterval();
           
        }

      
            
        

       
    }
}

