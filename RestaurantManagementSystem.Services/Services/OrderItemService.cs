using Microsoft.EntityFrameworkCore;
using RestaurantManagementSystem.Core.Entities;
using RestaurantManagementSystem.DataAccess.Data;
using RestaurantManagementSystem.Services.Interfaces;


namespace RestaurantManagementSystem.Services.Services
{
    public class OrderItemService:IOrderItemService
    {
        private readonly RestaurantContext _context;
        public OrderItemService()
        {
            _context = new RestaurantContext();
        }

        public OrderItem GetById(int? id)
        {
            if (id is null)
                throw new Exception("Id is null.");
            var existOrderItem = _context.OrderItems.SingleOrDefault(o => o.Id == id);
            if (existOrderItem == null)
                throw new Exception($"Menuitem not found with Id {id}");
            return existOrderItem   ;
        }
        public async Task<OrderItem> GetByIdAsync(int? id)
        {
            if (id is null)
                throw new Exception("Id is null.");
            var existOrderItem = await _context.OrderItems.SingleOrDefaultAsync(o => o.Id == id);
            if (existOrderItem == null)
                throw new Exception($"Menuitem not found with Id {id}");
            return existOrderItem;
        }
        public OrderItem RemoveOrderItem(int? id)
        {
            if (id is null)
                throw new Exception("Id is null.");
            var existOrderItem = GetById(id);
            _context.OrderItems.Remove(existOrderItem);
            _context.SaveChanges();
            return existOrderItem;
        }
        public async Task<OrderItem> RemoveOrderItemAsync(int? id)
        {
            if (id is null)
                throw new Exception("Id is null.");
            var existOrderItem = GetById(id);
            _context.OrderItems.Remove(existOrderItem);
            await _context.SaveChangesAsync();
            return existOrderItem;
        }
    }
}
