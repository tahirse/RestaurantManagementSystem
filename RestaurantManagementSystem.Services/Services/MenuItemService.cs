using Microsoft.EntityFrameworkCore;
using RestaurantManagementSystem.Core.Entities;
using RestaurantManagementSystem.DataAccess.Data;
using RestaurantManagementSystem.Services.Interface;


namespace RestaurantManagementSystem.Services.Services
{
    public class MenuItemService : IMenuItemService
    {
        private readonly RestaurantContext _context;
        public MenuItemService()
        {
            _context = new RestaurantContext();
        }
        public List<MenuItem> GetMenuItems() => _context.MenuItems.ToList();

        public async Task<List<MenuItem>> GetMenuItemsAsync() => await _context.MenuItems.ToListAsync();

        public void Create(MenuItem menuItem)
        {
            if (_context.MenuItems.Any(m => m.Name == menuItem.Name))
            {
                throw new Exception("Already exist with name!!!");
            }
            _context.MenuItems.Add(menuItem);
            _context.SaveChanges();
        }
        public void EditMenuItem()
        {
            Console.Write("Deyishdirmek istediyiniz menyu  Id-ni daxil edin:");
            int No;
            while (!int.TryParse(Console.ReadLine(), out No) || No <= 0)
            {
                Console.Write("Duzgun melumat daxil edin");
            }
            var existMenuItem = _context.MenuItems.FirstOrDefault(item => item.Id == No);
            if (existMenuItem != null)
            {
                Console.Write("Yeni adi daxil edin: ");
                string name = Console.ReadLine();
                Console.Write("Yeni qiymet daxil edin: ");
                decimal cost;
                while (!decimal.TryParse(Console.ReadLine(), out cost) || cost <= 0)
                {
                    Console.Write("Duzgun qiymet daxil edin: ");
                }
                Console.Write("Categoriya daxil edin: ");
                string category = Console.ReadLine();

                existMenuItem.Name = name;
                existMenuItem.Price = cost;
                existMenuItem.Category = category;
                _context.SaveChanges();
                Console.WriteLine("Menyu ugurla yenilendi.");
            }
            else
            {
                Console.WriteLine("Verilen ID ile uygun menyu novu tapılmadı.");
            }
        }
        public MenuItem GetById(int? id)
        {
            if (id is null)
                throw new Exception("Id is null!!!");
            var existMenuItem = _context.MenuItems.SingleOrDefault(m => m.Id == id);
            if (existMenuItem == null)
                throw new Exception($"Menuitem not found with Id {id}");
            return existMenuItem;
        }

        public void RemoveMenuItem(int? id)
        {
            var existMenuItem = GetById(id);
            var exsistMenuItem = _context.MenuItems.SingleOrDefaultAsync(m => m.Id == id);
            _context.MenuItems.Remove(existMenuItem);
            _context.SaveChanges();
        }

        public void AddMenuItem(string name, decimal price, string category)
        {
            if (string.IsNullOrEmpty(name) || price <= 0 || string.IsNullOrEmpty(category))
                throw new Exception("Invalid MenuItem details!");
            var existingMenuItem = _context.MenuItems
                .SingleOrDefault(m => m.Name == name && m.Category == category);
            if (existingMenuItem != null)
                throw new Exception("MenuItem with the same name and category already exists!");
            var newMenuItem = new MenuItem
            {
                Name = name,
                Price = price,
                Category = category
            };
            _context.MenuItems.Add(newMenuItem);
            _context.SaveChanges();
        }

        public List<MenuItem> GetMenuItemsByCategory()
        {
            string category = default;
            if (string.IsNullOrEmpty(category))
                throw new Exception("Category cannot be null!!!");
            var menuItems = _context.MenuItems
                 .Where(m => m.Category == category)
                 .ToList();
            if (menuItems.Count == 0)
                throw new Exception($"With category ({category}) not found menuitem");
            return menuItems;
        }
        public async Task<List<MenuItem>> GetMenuItemsByCategoryAsync(string category)
        {
            if (string.IsNullOrEmpty(category))
                throw new Exception("Category cannot be null!!!");
            var menuItems = await _context.MenuItems
                 .Where(m => m.Category == category)
                 .ToListAsync();
            if (menuItems.Count == 0)
                throw new Exception($"With category ({category}) not found menuitem");
            return menuItems;
        }
        public List<MenuItem> GetMenuItemsByPrice(decimal price)
        {
            if (price <= 0)
                throw new Exception("Category cannot be null!!!");
            var menuItems = _context.MenuItems
                 .Where(m => m.Price == price)
                 .ToList();
            if (menuItems.Count == 0)
                throw new Exception($"With ({price}) not found menuitem");
            return menuItems;
        }

        public List<MenuItem> SearchMenuItems(string search)
        {
            if (string.IsNullOrEmpty(search))
                throw new Exception("Serch cannot be null.");
            var menuItems = _context.MenuItems
                .Where(m => m.Name.Contains(search) || m.Category.Contains(search) || m.Price.ToString().Contains(search))
                .ToList();
            if (menuItems.Count == 0)
                throw new Exception($"Not found ({search}) with menuitem!!!");
            foreach (var item in menuItems)
            {
                Console.WriteLine(item.ToString());
            }
            return menuItems;
        }


    }
}
