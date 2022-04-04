using DeliveryDevil.Domain;
using DeliveryDevil.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace DeliveryDevil.API.DTO
{
    public class OrderDto
    {
        public int OrderId { get; set; }
        
        [Required]
        [Range(1, int.MaxValue)]
        public int CustomerId { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int RestaurantId { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int DeliveryAddressId { get; set; }

        [Required]
        [Range(0.1, 1000)]
        public decimal CollectionAmount { get; set; }
        public OrderStatus Status { get; set; } = OrderStatus.Created;

        public bool? Tip { get; set; }

        public CustomerDto? Customer { get; set; }
        public RestaurantDto? Restaurant { get; set; }
        public AddressDto? DeliveryAddress { get; set; }
    }

    public static class OrderDtoExtensions
    {
        public static OrderDto? FromDomain(this Order domain)
        {
            if (domain == null) return null;
            return new OrderDto
            {
                CustomerId = domain.CustomerId,
                OrderId = domain.OrderId,
                DeliveryAddressId = domain.DeliveryAddressId,
                RestaurantId = domain.RestaurantId,
                CollectionAmount = domain.CollectionAmount,
                Status = (OrderStatus)domain.Status,
                Tip = domain.Tip,
                Restaurant = domain.Restaurant.FromDomain(),
                Customer = domain.Customer.FromDomain(),
                DeliveryAddress = domain.DeliveryAddress.FromDomain()
            };
        }

        public static Order? ToDomain(this OrderDto dto)
        {
            if (dto == null) return null;
            return new Order
            {
                CustomerId = dto.CustomerId,
                OrderId = dto.OrderId,
                DeliveryAddressId = dto.DeliveryAddressId,
                RestaurantId = dto.RestaurantId,
                CollectionAmount = dto.CollectionAmount,
                Status = (byte)dto.Status,
                Tip = dto.Tip,
                Restaurant = dto.Restaurant.ToDomain(),
                Customer = dto.Customer.ToDomain(),
                DeliveryAddress = dto.DeliveryAddress.ToDomain()
            };
        }
    }

}