using Microsoft.EntityFrameworkCore;
using RestaurantManagementSystem.Core.Entities;
using RestaurantManagementSystem.DataAccess.Data;
using RestaurantManagementSystem.Services.Interfaces;
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
        public async Task CreateAsync(MenuItem menuItem)
        {
            if (await _context.MenuItems.AnyAsync(m => m.Name == menuItem.Name))
            {
                throw new Exception("Already exist with name!!!");
            }
            await _context.MenuItems.AddAsync(menuItem);
            await _context.SaveChangesAsync();
        }
        public MenuItem EditMenuItem(int? id, string name, decimal price)
        {
            if (id is null)
                throw new Exception("Id is null!!!");
            var existMenuItem = _context.MenuItems.SingleOrDefault(m => m.Id == id);
            if (existMenuItem == null)
                throw new Exception($"Menuitem not found with Id {id}");
            existMenuItem.Name = name;
            existMenuItem.Price = price;
            _context.SaveChanges();
            return existMenuItem;
        }
        public async Task<MenuItem> EditMenuItemAsync(int? id, string name, decimal price)
        {
            if (id is null)
                throw new Exception("Id is null!!!");
            var existMenuItem = await _context.MenuItems.SingleOrDefaultAsync(m => m.Id == id);
            if (existMenuItem == null)
                throw new Exception($"Menuitem not found with Id {id}");
            existMenuItem.Name = name;
            existMenuItem.Price = price;
            await _context.SaveChangesAsync();
            return existMenuItem;
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
        public async Task<MenuItem> GetByIdAsync(int? id)
        {
            if (id is null)
                throw new Exception("Id is null!!!");
            var existMenuItem = await _context.MenuItems.SingleOrDefaultAsync(m => m.Id == id);
            if (existMenuItem == null)
                throw new Exception($"Menuitem not found with Id {id}");
            return existMenuItem;
        }
        public MenuItem RemoveMenuItem(int? id)
        {
            if (id is null)
                throw new Exception("Id is null!!!");
            var existMenuItem = GetById(id);
            _context.MenuItems.Remove(existMenuItem);
            _context.SaveChanges();
            return existMenuItem;
        }
        public async Task<MenuItem> RemoveMenuItemAsync(int? id)
        {
            if (id is null)
                throw new Exception("Id is null!!!");
            var existMenuItem = GetById(id);
            _context.MenuItems.Remove(existMenuItem);
            await _context.SaveChangesAsync();
            return existMenuItem;
        }
        public MenuItem AddMenuItem(int? id, string name, decimal price, string category)
        {
            if (id is null)
                throw new Exception("Id is null!!!");
            var existMenuItem = GetById(id);
            if (existMenuItem != null)
                throw new Exception("MenuItem with this id exists!!!");
            if (string.IsNullOrEmpty(name) || price <= 0 || string.IsNullOrEmpty(category))
                throw new Exception("MenuItem details!!!");
            var existingMenuItem = _context.MenuItems.SingleOrDefault(m => m.Name == name && m.Price == price && m.Category == category);
            if (existingMenuItem != null)
                throw new Exception("MenuItem with name price and category exists!!!");
            var newMenuItem = new MenuItem
            {
                Id = id.Value,
                Name = name,
                Price = price,
                Category = category
            };
            _context.MenuItems.Add(newMenuItem);
            Console.WriteLine($"MenuItem Name: {name}, MenuItem Price: {price}, MenuItem Category: {category}");
            _context.SaveChanges();

            return newMenuItem;
        }
        public async Task< MenuItem> AddMenuItemAsync(int? id, string name, decimal price, string category)
        {
            if (id is null)
                throw new Exception("Id is null!!!");
            var existMenuItem = GetByIdAsync(id);
            if (existMenuItem != null)
                throw new Exception("MenuItem with this id exists!!!");
            if (string.IsNullOrEmpty(name) || price <= 0 || string.IsNullOrEmpty(category))
                throw new Exception("MenuItem details!!!");
            var existingMenuItem = await _context.MenuItems.SingleOrDefaultAsync(m => m.Name == name && m.Price == price && m.Category == category);
            if (existingMenuItem != null)
                throw new Exception("MenuItem with name price and category exists!!!");
            var newMenuItem = new MenuItem
            {
                Id = id.Value,
                Name = name,
                Price = price,
                Category = category
            };
            _context.MenuItems.Add(newMenuItem);
            Console.WriteLine($"MenuItem Name: {name}, MenuItem Price: {price}, MenuItem Category: {category}");
            await _context.SaveChangesAsync();
            return newMenuItem;
        }
        public List<MenuItem> GetMenuItemsByCategory(string category)
        {
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
            if (price<=0)
                throw new Exception("Category cannot be null!!!");
            var menuItems = _context.MenuItems
                 .Where(m => m.Price == price)
                 .ToList();
            if (menuItems.Count == 0)
                throw new Exception($"With ({price}) not found menuitem");
            return menuItems;
        }
        public async Task<List<MenuItem>> GetMenuItemsByPriceAsync(decimal price)
        {
            if (price <= 0)
                throw new Exception("Category cannot be null!!!");
            var menuItems = await _context.MenuItems
                 .Where(m => m.Price == price)
                 .ToListAsync();
            if (menuItems.Count == 0)
                throw new Exception($"With ({price}) not found menuitem!!!");
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
            return menuItems;
        }
        public async Task<List<MenuItem>> SearchMenuItemsAsync(string search)
        {
            if (string.IsNullOrEmpty(search))
                throw new Exception("Serch cannot be null.");
            var menuItems = await _context.MenuItems
                .Where(m => m.Name.Contains(search) || m.Category.Contains(search) || m.Price.ToString().Contains(search))
                .ToListAsync();
            if (menuItems.Count == 0)
                throw new Exception($"Not found ({search}) with menuitem!!!");
            return menuItems;
        }
    }
}
