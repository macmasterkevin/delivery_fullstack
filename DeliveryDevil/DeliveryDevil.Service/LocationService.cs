using DeliveryDevil.Domain;
using DeliveryDevil.Domain.Context;
using DeliveryDevil.Domain.Models;
using DeliveryDevil.Helpers;
using Microsoft.EntityFrameworkCore;

namespace DeliveryDevil.Service
{
    public class LocationService : ILocationService
    {
        public readonly DeliveryDevilContext _context;
        private readonly Paging _paging;

        public LocationService(DeliveryDevilContext context, Paging paging)
        {
            _context = context;
            _paging = paging;
        }

        private IQueryable<Address> Addresses()
        {
            return _context.Addresses.AsNoTracking()
                .Include(x => x.Region);
        }

        public async Task<Address> Create(Address address)
        {
            _context.Add(address);
            await _context.SaveChangesAsync();
            return address;
        }

        public async Task Delete(int addressId)
        {
            _context.Remove(new Address { AddressId = addressId });
            await _context.SaveChangesAsync();
        }

        public Task<Address?> Get(int addressId)
        {
            return Addresses()
                .FirstOrDefaultAsync(x => x.AddressId == addressId);
        }

        public Task<List<Region>> GetAllRegions()
        {
            return _context.Regions.AsNoTracking()
                .Paginate(_paging).ToListAsync();
        }

        public async Task<Address> Update(Address address)
        {
            _context.Update(address);
            await _context.SaveChangesAsync();
            return address;
        }
    }
}