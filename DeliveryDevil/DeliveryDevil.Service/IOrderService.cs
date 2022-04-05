using DeliveryDevil.Domain;
using DeliveryDevil.Domain.Models;

namespace DeliveryDevil.Service
{
    public interface IOrderService
    {
        public Task<Order?> Get(int orderId);
        public Task<List<Order>> GetAll();
        public Task<Order> Create(Order order);
        public Task<Order> Update(Order order);
        public Task Complete(int orderId, bool didTip);
        public Task<List<Order>> GetHistory(int customerId, bool orderByRecent, int pageNumber, int pageSize);
        Task Delete(int orderId);
    }
}