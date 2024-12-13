using Microsoft.EntityFrameworkCore;
using RestaurantManagementSystem.Core.Entities;
using RestaurantManagementSystem.DataAccess.Data;
using RestaurantManagementSystem.Services.Interface;



namespace RestaurantManagementSystem.Services.Services
{
    public class OrderService : IOrderService
    {
        private readonly RestaurantContext _context;
        public OrderService()
        {
            _context = new RestaurantContext();
        }

        public List<OrderItem> GetOrderItems() => _context.OrderItems.ToList();

        public async Task<List<OrderItem>> GetOrderItemsAsync() => await _context.OrderItems.ToListAsync();

        public void Create(OrderItem orderItem)
        {
            if (_context.OrderItems.Any(o => o.Id == orderItem.Id))
            {
                throw new Exception("Already exist with Id!!!");
            }
            _context.OrderItems.Add(orderItem);
            _context.SaveChanges();
        }
        public async Task CreateAsync(OrderItem orderItem)
        {
            if (await _context.OrderItems.AnyAsync(o => o.Id == orderItem.Id))
            {
                throw new Exception("Already exist with id!!!");
            }
            await _context.OrderItems.AddAsync(orderItem);
            await _context.SaveChangesAsync();
        }

        public OrderItem GetById(int? id)
        {
            if (id is null)
                throw new Exception("Id is null!!!");
            var existOrderItem = _context.OrderItems.SingleOrDefault(m => m.Id == id);
            if (existOrderItem == null)
                throw new Exception($"Ordertem not found with Id {id}");
            return existOrderItem;
        }
        public async Task<OrderItem> GetByIdAsync(int? id)
        {
            if (id is null)
                throw new Exception("Id is null!!!");
            var exsistOrderItem = await _context.OrderItems.SingleOrDefaultAsync(m => m.Id == id);
            if (exsistOrderItem == null)
                throw new Exception($"Orderitem not found with Id {id}");
            return exsistOrderItem;
        }



    }
}
