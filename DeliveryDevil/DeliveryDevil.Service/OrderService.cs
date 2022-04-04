using DeliveryDevil.Domain;
using DeliveryDevil.Domain.Context;
using DeliveryDevil.Domain.Models;
using DeliveryDevil.Helpers;
using Microsoft.EntityFrameworkCore;

namespace DeliveryDevil.Service
{
    public class OrderService : IOrderService
    {
        public readonly DeliveryDevilContext _context;
        private readonly Paging _paging;

        public OrderService(DeliveryDevilContext context, Paging paging)
        {
            _context = context;
            _paging = paging;
        }

        private IQueryable<Order> Orders()
        {
            return _context.Orders.AsNoTracking()
                .Include(o => o.Customer)
                .Include(x => x.DeliveryAddress).ThenInclude(x => x.Region)
                .Include(o => o.Restaurant)
                .ThenInclude(x => x.Address).ThenInclude(x => x.Region);
        }

        public Task<Order?> Get(int orderId)
        {
            return Orders()
                .FirstOrDefaultAsync(o => o.OrderId == orderId);
        }

        public Task<List<Order>> GetAll()
        {
            return Orders()
                .Paginate(_paging).ToListAsync();
        }

        public Task<List<Order>> GetHistory(int customerId, bool orderByRecent)
        {
            var query = Orders()
                .Where(x => x.CustomerId == customerId);

            if (orderByRecent)
                query = query.OrderByDescending(o => o.CreatedDate);

            return query.Paginate(_paging).ToListAsync();
        }
        public async Task Complete(int orderId, bool didTip)
        {
            var order = await _context.Orders
                .FirstOrDefaultAsync(o => o.OrderId == orderId);
            if (order == null) return;

            order.Status = (byte)OrderStatus.Delivered;
            order.Tip = didTip;

            await _context.SaveChangesAsync();
        }

        public async Task<Order> Create(Order order)
        {
            _context.Add(order);
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task<Order> Update(Order order)
        {
            _context.Update(order);
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task Delete(int orderId)
        {
            _context.Remove(new Order { OrderId = orderId });
            await _context.SaveChangesAsync();
        }
    }
}