using Microsoft.EntityFrameworkCore;
using RestaurantManagementSystem.Core.Entities;
using RestaurantManagementSystem.DataAccess.Data;
using RestaurantManagementSystem.Services.Interfaces;
using System.Diagnostics;


namespace RestaurantManagementSystem.Services.Services
{
    public class MenuItemService:IMenuItemService
    {
        private readonly RestaurantContext _context;
        public MenuItemService()
        {
            _context = new RestaurantContext();
        }

        public List<MenuItem> GetMenuItems()=> _context.MenuItems.ToList();

        public  async Task<List<MenuItem>> GetMenuItemsAsync()=> await _context.MenuItems.ToListAsync();
       
        public void Create(MenuItem menuItem)
        {
            if (_context.MenuItems.Any(m=>m.Name==menuItem.Name))
            {
                throw new Exception("Already exist with name");
            }
            _context.MenuItems.Add(menuItem);
            _context.SaveChanges();
        }
        public async Task CreateAsync(MenuItem menuItem)
        {
            if (await _context.MenuItems.AnyAsync(m => m.Name == menuItem.Name))
            {
                throw new Exception("Already exist with name");
            }
            await _context.MenuItems.AddAsync(menuItem);
            await _context.SaveChangesAsync();
        }

        public MenuItem EditMenuItem(int? id, string name, decimal price)
        {
            if (id is null)
                throw new Exception("Id is null.");
            var existMenuItem =  _context.MenuItems.SingleOrDefault(m => m.Id == id);
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
                throw new Exception("Id is null.");
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
                throw new Exception("Id is null.");
            var existMenuItem = _context.MenuItems.SingleOrDefault(m => m.Id == id);
            if (existMenuItem == null)
                throw new Exception($"Menuitem not found with Id {id}");
            return existMenuItem;
        }
        public async Task<MenuItem> GetByIdAsync(int? id)
        {
            if (id is null)
                throw new Exception("Id is null.");
            var existMenuItem = await _context.MenuItems.SingleOrDefaultAsync(m => m.Id == id);
            if (existMenuItem == null)
                throw new Exception($"Menuitem not found with Id {id}");
            return existMenuItem;
        }
        public MenuItem RemoveMenuItem (int? id)
        {
            if (id is null)
                throw new Exception("Id is null.");
            var existMenuItem = GetById(id);
            _context.MenuItems.Remove(existMenuItem);
            _context.SaveChanges();
            return existMenuItem;
        }
        public async Task <MenuItem> RemoveMenuItemAsync(int? id)
        {
            if (id is null)
                throw new Exception("Id is null.");
            var existMenuItem = GetById(id);
            _context.MenuItems.Remove(existMenuItem);
            await _context.SaveChangesAsync();
            return existMenuItem;
        }


    }


    }
}
