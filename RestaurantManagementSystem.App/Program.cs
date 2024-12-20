using Microsoft.Identity.Client;
using RestaurantManagementSystem.App.Controllers;
using RestaurantManagementSystem.Core.Entities;


DisplayMenyu();


static void DisplayMenyu()
{
    bool data = true;

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
            case "0":
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
        Console.WriteLine("0 Evvelki menyuya qayit");

        string menuSelect = Console.ReadLine();
        
        switch (menuSelect)
        {


            case "1":
                Console.WriteLine("Menyu elave etmek ucun melumatlari daxil edin:");
                Console.Write("Menyu  adi: ");
                string name = Console.ReadLine();
                Console.Write("Qiymet: ");
                decimal price = Convert.ToDecimal(Console.ReadLine());
                Console.Write("Kateqoriya: ");
                string category = Console.ReadLine();
                menuController.AddMenuItem(name, price, category);
                Console.WriteLine($"Menyu adi:{name}, Qiymeti: {price}, Category: {category}");
                    break;
                break;
            case "2":
                Console.WriteLine("Mocvud olan menyu");
                menuController.GetMenuItems().ForEach(x => Console.WriteLine(x));
               
                //int num =int.Parse(Console.ReadLine());
                menuController.EditMenuItem();
                break;
            case "3":
                Console.WriteLine("Movcud olan menyunun siyahisi");
                menuController.GetMenuItems().ForEach(x => Console.WriteLine(x));
                Console.WriteLine("Silmek istediyiniz enyu nomresini daxil edin");
                int num=int.Parse(Console.ReadLine());  
                menuController.RemoveMenuItem();
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
    bool Select = true;
    OrderController orderController = new OrderController();

    while (Select)
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

        string orderSelect = Console.ReadLine();
        switch (orderSelect)
        {
            case "1":
                Console.WriteLine("Sifarish nomresi daxil edin");
                int data=int.Parse(Console.ReadLine());
                Console.WriteLine("Menyu nomresi daxil edin");
                data = int.Parse(Console.ReadLine());
                Console.WriteLine("Count daxil edin");
                data=int.Parse(Console.ReadLine());
                orderController.AddOrderItem();
                break;
            case "2":
                 
                 orderController.RemoveOrder();
                break;
            case "3":
                 orderController.GetOrderItems().ForEach(x => Console.WriteLine(x));
                break;
            case "4":
                 orderController.GetOrdersByDatesInterval();
                break;
            case "5":
                orderController.GetOrdersByPriceInterval();
                break;
            case "6":
                 Console.WriteLine("Hansi tarixe olan sifarisihi gormek isteyirsiinizse tarixi daxil edin");
                 data = int.Parse(Console.ReadLine());
                 orderController.GetOrderByDate();
                break;
            case "7":
                Console.WriteLine("Sifarish nomresini daxil edin");
                data = int.Parse(Console.ReadLine());
                orderController.GetOrderByNo();
                break;
            case "0":
                DisplayMenyu();
                Select = false;
                break;
            default:
                Console.WriteLine("Yanlısh secim etdiniz.");
                break;


        }
    

    }

}

