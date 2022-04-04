using DeliveryDevil.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace DeliveryDevil.API.DTO
{
    public class AddressDto
    {
        public int AddressId { get; set; }
        [Required]
        public string Address1 { get; set; } = null!;
        [Required]
        public string City { get; set; } = null!;
        [Required]
        [Range(1, int.MaxValue)]
        public int RegionId { get; set; }
        [Required]
        public string PostalCode { get; set; } = null!;

        public RegionDto? Region { get; set; }
    }

    public static class AddressDtoExtensions
    {
        public static AddressDto? FromDomain(this Address domain)
        {
            if (domain == null) return null;
            return new AddressDto
            {
                Address1 = domain.Address1,
                AddressId = domain.AddressId,
                City = domain.City,
                RegionId = domain.RegionId,
                PostalCode = domain.PostalCode,
                Region = domain.Region.FromDomain()
            };
        }

        public static Address? ToDomain(this AddressDto dto)
        {
            if (dto == null) return null;
            return new Address
            {
                Address1 = dto.Address1,
                AddressId = dto.AddressId,
                City = dto.City,
                RegionId = dto.RegionId,
                PostalCode = dto.PostalCode,
                Region = dto.Region.ToDomain()
            };
        }
    }
}
