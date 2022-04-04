using DeliveryDevil.Domain;
using DeliveryDevil.Domain.Models;

namespace DeliveryDevil.Service
{
    public interface IRestaurantService
    {
        public Task<Restaurant?> Get(int restaurantId);
        public Task<List<Restaurant>> GetAll();
        public Task<Restaurant> Create(Restaurant restaurant);
        public Task<Restaurant> Update(Restaurant restaurant);
        Task Delete(int restaurantId);
    }
}