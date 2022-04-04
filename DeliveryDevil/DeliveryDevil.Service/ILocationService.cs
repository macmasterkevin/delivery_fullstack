using DeliveryDevil.Domain;
using DeliveryDevil.Domain.Models;

namespace DeliveryDevil.Service
{
    public interface ILocationService
    {
        public Task<Address?> Get(int addressId);
        public Task<Address> Create(Address address);
        public Task<Address> Update(Address address);
        Task Delete(int addressId);

        public Task<List<Region>> GetAllRegions();
    }
}