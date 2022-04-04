using DeliveryDevil.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace DeliveryDevil.API.DTO
{
    public class RestaurantDto
    {
        public int RestaurantId { get; set; }
        [Required]
        public string Name { get; set; } = null!;
        [Required]
        [Range(1, int.MaxValue)]
        public int AddressId { get; set; }

        public AddressDto? Address { get; set; }
    }

    public static class RestaurantDtoExtensions
    {
        public static RestaurantDto? FromDomain(this Restaurant domain)
        {
            if (domain == null) return null;
            return new RestaurantDto
            {
                RestaurantId = domain.RestaurantId,
                Name = domain.Name,
                AddressId = domain.AddressId,
                Address = domain.Address.FromDomain()
            };
        }

        public static Restaurant? ToDomain(this RestaurantDto dto)
        {
            if (dto == null) return null;
            return new Restaurant
            {
                RestaurantId = dto.RestaurantId,
                Name = dto.Name,
                AddressId = dto.AddressId,
                Address = dto.Address.ToDomain()
            };
        }
    }
}
