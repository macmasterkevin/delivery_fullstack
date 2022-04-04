using DeliveryDevil.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DeliveryDevil.API.DTO
{
    public class CountryDto
    {
        public int CountryId { get; set; }
        [Required]
        public string Name { get; set; } = null!;
    }

    public static class CountryDtoExtensions
    {
        public static CountryDto? FromDomain(this Country domain)
        {
            if (domain == null) return null;
            return new CountryDto
            {
                CountryId = domain.CountryId,
                Name = domain.Name
            };
        }

        public static Country? ToDomain(this CountryDto dto)
        {
            if (dto == null) return null;
            return new Country
            { 
                CountryId = dto.CountryId,
                Name = dto.Name
            };
        }
    }
}
