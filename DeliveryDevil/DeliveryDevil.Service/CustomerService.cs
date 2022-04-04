using DeliveryDevil.Domain;
using DeliveryDevil.Domain.Context;
using DeliveryDevil.Domain.Models;
using DeliveryDevil.Helpers;
using Microsoft.EntityFrameworkCore;

namespace DeliveryDevil.Service
{
    public class CustomerService : ICustomerService
    {
        public readonly DeliveryDevilContext _context;
        private readonly Paging _paging;

        public CustomerService(DeliveryDevilContext context, Paging paging)
        {
            _context = context;
            _paging = paging;
        }

        private IQueryable<Customer> Customers()
        {
            return _context.Customers.AsNoTracking()
                .Include(x => x.DefaultAddress).ThenInclude(x => x.Region);
        }

        public async Task<Customer> Create(Customer customer)
        {
            _context.Add(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task Delete(int customerId)
        {
            _context.Remove(new Customer { CustomerId = customerId });
            await _context.SaveChangesAsync();
        }

        public async Task<Customer> Update(Customer customer)
        {
            _context.Update(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        public Task<Customer?> Get(int customerId)
        {
            return Customers()
                .FirstOrDefaultAsync(x => x.CustomerId == customerId);
        }

        public Task<List<Customer>> GetAll()
        {
            return Customers()
                .Paginate(_paging).ToListAsync();
        }
    }
}