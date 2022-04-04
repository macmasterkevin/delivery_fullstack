using DeliveryDevil.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace DeliveryDevil.API.DTO
{
    public class CustomerDto
    {
        public int CustomerId { get; set; }
        [Required]
        public string Name { get; set; } = null!;
        [Required]
        [Range(1, int.MaxValue)]
        public int DefaultAddressId { get; set; }

        public AddressDto? DefaultAddress { get; set; }
    }

    public static class CustomerDtoExtensions
    {
        public static CustomerDto? FromDomain(this Customer domain)
        {
            if (domain == null) return null;
            return new CustomerDto
            {
                CustomerId = domain.CustomerId,
                Name = domain.Name,
                DefaultAddressId = domain.DefaultAddressId,
                DefaultAddress = domain.DefaultAddress.FromDomain()
            };
        }

        public static Customer? ToDomain(this CustomerDto dto)
        {
            if (dto == null) return null;
            return new Customer
            {
                CustomerId = dto.CustomerId,
                Name = dto.Name,
                DefaultAddressId = dto.DefaultAddressId,
                DefaultAddress = dto.DefaultAddress.ToDomain()
            };
        }
    }
}
