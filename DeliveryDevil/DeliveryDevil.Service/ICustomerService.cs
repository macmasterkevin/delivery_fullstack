using DeliveryDevil.Domain;
using DeliveryDevil.Domain.Models;

namespace DeliveryDevil.Service
{
    public interface ICustomerService
    {
        public Task<Customer?> Get(int customerId);
        public Task<List<Customer>> GetAll();
        public Task<Customer> Create(Customer customer);
        public Task<Customer> Update(Customer customer);
        Task Delete(int customerId);
    }
}