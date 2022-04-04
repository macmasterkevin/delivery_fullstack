using System;
using System.Collections.Generic;

namespace DeliveryDevil.Domain.Models
{
    public partial class Restaurant
    {
        public Restaurant()
        {
            Orders = new HashSet<Order>();
        }

        public int RestaurantId { get; set; }
        public string Name { get; set; } = null!;
        public int AddressId { get; set; }

        public virtual Address Address { get; set; } = null!;
        public virtual ICollection<Order> Orders { get; set; }
    }
}
