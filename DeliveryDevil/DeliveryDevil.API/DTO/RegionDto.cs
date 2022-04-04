using DeliveryDevil.Domain.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace DeliveryDevil.API.DTO
{
    public class RegionDto
    {
        public int RegionId { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int CountryId { get; set; }
        [Required]
        public string Name { get; set; } = null!;

        public CountryDto? Country { get; set; } = null;
    }

    public static class RegionDtoExtensions
    {
        public static RegionDto? FromDomain(this Region domain)
        {
            if (domain == null) return null;
            return new RegionDto
            {
                RegionId = domain.RegionId,
                Name = domain.Name,
                Country = domain.Country.FromDomain()
            };
        }

        public static Region? ToDomain(this RegionDto dto)
        {
            if (dto == null) return null;
            return new Region
            {
                RegionId = dto.RegionId,
                Name = dto.Name,
                Country = dto.Country.ToDomain()
            };
        }
    }
}
