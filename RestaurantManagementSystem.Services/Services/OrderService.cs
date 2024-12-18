using Microsoft.EntityFrameworkCore;
using RestaurantManagementSystem.Core.Entities;
using RestaurantManagementSystem.DataAccess.Data;
using RestaurantManagementSystem.Services.Interface;
using System.Diagnostics;




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

        public void AddOrderItem(int orderNo, int menuItemId, int count)
        {
            var order = _context.Orders.Include(o => o.OrderItems).SingleOrDefault(o => o.Id == orderNo);
            if (order == null)
            {
                order = new Order
                {
                    Date = DateTime.Now,
                    OrderItems = new List<OrderItem>()
                };
                _context.Orders.Add(order);
                _context.SaveChanges();
            }
            var menuItem = _context.MenuItems.FirstOrDefault(m => m.Id == menuItemId);
            if (menuItem == null)
            {
                Console.WriteLine($"MenuItemId {menuItemId} ilə məhsul tapılmadı.");
                return;
            }
            var orderItem = new OrderItem
            {
                MenuItemId = menuItemId,
                Count = count,
                MenuItem = menuItem
            };
            order.OrderItems.Add(orderItem);
            order.TotalAmount = order.OrderItems.Sum(o => o.Count * o.MenuItem.Price);
            _context.SaveChanges();


        }
        public Order GetById(int? id)
        {
            if (id is null)
                throw new Exception("Id is null!!!");
            var exsistOrder = _context.Orders.Include(o => o.OrderItems).SingleOrDefault(o => o.Id == id);
            if (exsistOrder == null)
                throw new Exception($"Ordertem not found with Id {id}");
            return exsistOrder;

        }
        public void RemoveOrder(int? id)
        {
            var existOrder = GetById(id);
            var exsistOrder = _context.Orders.Include(o => o.OrderItems).SingleOrDefault(o => o.Id == id);
            if (existOrder == null)
                throw new Exception($"Order with id {id} not found.");
            foreach (var orderItem in existOrder.OrderItems)
            {
                _context.OrderItems.Remove(orderItem);
            }
            _context.Orders.Remove(existOrder);
            _context.SaveChanges();
        }
        public void GetOrderByNo()
        {         
            Console.WriteLine("Sifarish nömresini daxil edin:");
            string orderNoInput = Console.ReadLine();
            if (string.IsNullOrEmpty(orderNoInput))
            {
                Console.WriteLine("Sifarish nomresi daxil edilməyib.");
                return;
            }
            if (int.TryParse(orderNoInput, out int orderNo))
            {
                var order = _context.Orders.Include(o => o.OrderItems).ThenInclude(o => o.MenuItem).FirstOrDefault(o => o.Id == orderNo);
                if (order == null)
                    Console.WriteLine($"Sifarish nömresi {orderNo} ile sifarish tapılmadı.");
                else
                {
                    Console.WriteLine($"Sifariş Nömresi: {orderNo}");
                    foreach (var item in order.OrderItems)
                        Console.WriteLine($"Mehsul: {item.MenuItem.Name}, Miqdar: {item.Count}");
                }
            }
            else
                Console.WriteLine("Daxil etdiyiniz sifariş nömresi duzgun deyil.");
            
        }
        public void GetOrdersByDatesInterval()
        {
            Console.WriteLine("Ilk baxmaq istediyiniz sifarishlere uygun tarixi daxil edin");
            string startDateInput = Console.ReadLine();
            Console.WriteLine("Son baxmaq istediyiniz sifarishin tarixini daxil edin ");
            string endDateInput = Console.ReadLine();
            if (string.IsNullOrEmpty(startDateInput) || string.IsNullOrEmpty(endDateInput))
            {
                Console.WriteLine("Tarixler daxil edilmeyib");
                return;
            }

            if (DateTime.TryParse(startDateInput, out DateTime startDate) && DateTime.TryParse(endDateInput, out DateTime endDate))
            {
                if (startDate > endDate)
                {
                    Console.WriteLine("Son baxmaq istediyiniz tarix ilk baxmaq istediyiniz tarixinden sonra ola bilmez");
                    return;
                }

                var orders = _context.Orders
                                     .Where(o => o.Date >= startDate && o.Date <= endDate)
                                     .Include(o => o.OrderItems)
                                     .ThenInclude(oi => oi.MenuItem)
                                     .ToList();

                if (orders.Count == 0)
                {
                    Console.WriteLine($"Verilen tarixlere uygun sifarish tapılmadı");
                }
                else
                {
                    foreach (var order in orders)
                    {
                        Console.WriteLine($"Sifarish Nomresi: {order.Id}, Tarix: {order.Date.ToString()}, Umumi mebleq: {order.TotalAmount} AZN");

                        foreach (var item in order.OrderItems)
                        {
                            Console.WriteLine($"Mehsul: {item.MenuItem.Name}, Miqdar: {item.Count}, Qiymet: {item.MenuItem.Price * item.Count} AZN");
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("Daxil etdiyiniz tarixler duzgun deyil");
            }
        }
        public void GetOrdersByPriceInterval()
        {
            Console.WriteLine("Bashlangic meblegi daxil edin:");
            string startPriceInput = Console.ReadLine();
            Console.WriteLine("Bitme meblegini daxil edin:");
            string endPriceInput = Console.ReadLine();

            if (string.IsNullOrEmpty(startPriceInput) || string.IsNullOrEmpty(endPriceInput))
            {
                Console.WriteLine("Mebleqler daxil edilməyib");
                return;
            }

            if (decimal.TryParse(startPriceInput, out decimal startPrice) && decimal.TryParse(endPriceInput, out decimal endPrice))
            {
                if (startPrice > endPrice)
                {
                    Console.WriteLine("Bashlangıc meblegi bitme mebleginden boyuk ola bilmez.");
                    return;
                }

                var orders = _context.Orders
                                     .Where(o => o.TotalAmount >= startPrice && o.TotalAmount <= endPrice)
                                     .Include(o => o.OrderItems)
                                     .ThenInclude(oi => oi.MenuItem)
                                     .ToList();

                if (orders.Count == 0)
                {
                    Console.WriteLine($"Verilen mebləg aralıgında sifarish tapılmadı");
                }
                else
                {
                    foreach (var order in orders)
                    {
                        Console.WriteLine($"Sifarish Nomresi: {order.Id}, Tarix: {order.Date.ToString()}, Umumi Mebleg: {order.TotalAmount} AZN");

                        foreach (var item in order.OrderItems)
                        {
                            Console.WriteLine($"Mehsul: {item.MenuItem.Name}, Miqdar: {item.Count}, Qiymet: {item.MenuItem.Price * item.Count} AZN");
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("Daxil etdiyiniz qiymetler düzgün deyil.");
            }
        }
        public void GetOrderByDate()
        {
            Console.WriteLine("Tarixi daxil edin ");
            string dateInput = Console.ReadLine();

            if (string.IsNullOrEmpty(dateInput))
            {
                Console.WriteLine("Tarix daxil edilmeyib.");
                return;
            }

            if (DateTime.TryParse(dateInput, out DateTime date))
            {
                var orders = _context.Orders
                                     .Where(o => o.Date.Date == date.Date)
                                     .Include(o => o.OrderItems)
                                     .ThenInclude(oi => oi.MenuItem)
                                     .ToList();

                if (orders.Count == 0)
                {
                    Console.WriteLine($"Verilen tarixe hec bir sifarish verilmeyib");
                }
                else
                {
                    foreach (var order in orders)
                    {
                        Console.WriteLine($"Sifarish Nömresi: {order.Id}, Tarix: {order.Date.ToString()}, Umumi Mebleq: {order.TotalAmount} AZN");

                        foreach (var item in order.OrderItems)
                        {
                            Console.WriteLine($"Məhsul: {item.MenuItem.Name}, Miqdar: {item.Count}, Qiymət: {item.MenuItem.Price * item.Count} AZN");
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("Daxil etdiyiniz tarix düzgün deyil.");
            }
        }
        public void Create(OrderItem orderItem) => throw new NotImplementedException();
        void IOrderService.Create(OrderItem orderItem) => throw new NotImplementedException();
        Order IOrderService.GetById(int? id) => throw new NotImplementedException();
        List<OrderItem> IOrderService.GetOrderItems() => throw new NotImplementedException();
        void IOrderService.AddOrderItem() => throw new NotImplementedException();
    }
}
