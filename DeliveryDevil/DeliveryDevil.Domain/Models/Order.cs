using System;
using System.Collections.Generic;

namespace DeliveryDevil.Domain.Models
{
    public partial class Order
    {
        public int OrderId { get; set; }
        public int DeliveryAddressId { get; set; }
        public int CustomerId { get; set; }
        public int RestaurantId { get; set; }
        public decimal CollectionAmount { get; set; }
        public byte Status { get; set; }
        public bool? Tip { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? LastUpdated { get; set; }

        public virtual Customer Customer { get; set; } = null!;
        public virtual Address DeliveryAddress { get; set; } = null!;
        public virtual Restaurant Restaurant { get; set; } = null!;
    }
}
