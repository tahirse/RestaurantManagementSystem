using Microsoft.Identity.Client;
using RestaurantManagementSystem.App.Controllers;
using RestaurantManagementSystem.Core.Entities;
// OrderController orderController = new OrderController();
//orderController.Create();
// MenuController menuController = new MenuController();
// menuController.Create();
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
//orderController.GetOrdersByPriceInterval();

DisplayMenyu();


static void DisplayMenyu()
{


    bool data = true;
    OrderController orderController = new OrderController();
    MenuController menuController = new MenuController();
    while (data)
    {
        Console.WriteLine("Restoran sifarish sistemi");
        Console.WriteLine("1 Menu uzerinde emeliyyat aparmaq");
        Console.WriteLine("2 Sifarisler uzerinde emeliyyat aparmaq");
        Console.WriteLine("0 Sistemden cixmaq");

        string select = Console.ReadLine();
        switch (select)
        {
            case "1":
                MenuOperation();
                break;
            case "2":
                OrderOperation();
                break;
            case "3":
                Console.Write("Sistemden cixish");
                data = false;
                break;

            default:
                Console.Write("Yalnish secim etmisiniz yeniden daxil edin");
                break;


        }
    }

}
static void MenuOperation()
{
    MenuController menuController = new MenuController();
    bool menu = true;
    while (menu)
    {
        Console.WriteLine("Mehsullar uzerinde aparila bilinecek emeliyyatlar");
        Console.WriteLine("1 Yeni item elave et ");
        Console.WriteLine("2 Item uzerinde duzelis et");
        Console.WriteLine("3 Item sil ");
        Console.WriteLine("4 Butun Item-lari goster ");
        Console.WriteLine("5 Categoriyasina gore menu item-lari goster");
        Console.WriteLine("6 Qiymet araligina gore menu item-lar goster");
        Console.WriteLine("7 Menu itemlar arasinda ada gore axtaris et");
        Console.WriteLine("0 Evvelki menyuya qayıt");

        string menuSelect = Console.ReadLine();

        switch (menuSelect)
        {

            case "1":
                Console.WriteLine("MenuItemName daxil edin");
                string Name= Console.ReadLine();
                Console.WriteLine("Price daxil edin");
                decimal Data=Convert.ToDecimal(Console.ReadLine());
                Console.WriteLine("Category daxil edin");
                string Category= Console.ReadLine();
                menuController.AddMenuItem();
                break;

            case "2":
                menuController.RemoveMenuItem();
                break;

            case "3":
                menuController.EditMenuItem();
                break;

            case "4":
                menuController.GetMenuItems().ForEach(x => Console.WriteLine(x));
                break;

            case "5":
                menuController.GetMenuItemsByCategory();
                break;

            case "6":
                Console.Write("Minimum qiymeti daxil edin: ");
                decimal Price = decimal.Parse(Console.ReadLine());
                menuController.GetMenuItemsByPrice(Price);
                break;

            case "7":
                Console.Write("Axtarılacaq adı daxil edin: ");
                string search = Console.ReadLine();
                menuController.SearchMenuItems(search);
                break;
           
            case "0":
                DisplayMenyu();
                menu = false;
                break;

            default:
                Console.WriteLine("Yanlısh secim etdiniz.");
                break;
        }

    }
}
static void OrderOperation()
{

    bool orderSelect = true;

    while (orderSelect)
    {
        Console.WriteLine("Sifarisler uzerinde aparila bilinecek emeliyyatlar");
        Console.WriteLine("1 Yeni sifaris elave etmek");
        Console.WriteLine("2 Sifarisin legvi");
        Console.WriteLine("3 Butun sifarislerin ekrana cixarilmasi");
        Console.WriteLine("4 Verilen tarix araligina gore sifarislrein gosterilmesi");
        Console.WriteLine("5 Verilen mebleg araligina gore sifarislerin gosterilmesi");
        Console.WriteLine("6 Verilmis bir tarixde olan sifarislerin gosterilmesi");
        Console.WriteLine("7 Verilmis nomreye esasen hemin nomreli sifarisin melumatlarinin gosterilmesi");
        Console.WriteLine("0 Evveli menuya qayit");
    }

}

