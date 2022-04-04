using DeliveryDevil.Domain;
using DeliveryDevil.Domain.Context;
using DeliveryDevil.Domain.Models;
using DeliveryDevil.Helpers;
using Microsoft.EntityFrameworkCore;

namespace DeliveryDevil.Service
{
    public class RestaurantService : IRestaurantService
    {
        public readonly DeliveryDevilContext _context;
        private readonly Paging _paging;

        public RestaurantService(DeliveryDevilContext context, Paging paging)
        {
            _context = context;
            _paging = paging;
        }

        private IQueryable<Restaurant> Restaurants()
        {
            return _context.Restaurants.AsNoTracking()
                .Include(x => x.Address).ThenInclude(x => x.Region);
        }

        public async Task<Restaurant> Create(Restaurant restaurant)
        {
            _context.Add(restaurant);
            await _context.SaveChangesAsync();
            return restaurant;
        }

        public async Task Delete(int restaurantId)
        {
            _context.Remove(new Restaurant { RestaurantId = restaurantId });
            await _context.SaveChangesAsync();
        }

        public async Task<Restaurant> Update(Restaurant restaurant)
        {
            _context.Update(restaurant);
            await _context.SaveChangesAsync();
            return restaurant;
        }

        public Task<Restaurant?> Get(int restaurantId)
        {
            return Restaurants()
                .FirstOrDefaultAsync(x => x.RestaurantId == restaurantId);
        }

        public Task<List<Restaurant>> GetAll()
        {
            return Restaurants()
                .Paginate(_paging).ToListAsync();
        }
    }
}