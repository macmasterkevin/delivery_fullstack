using System;
using System.Collections.Generic;

namespace DeliveryDevil.Domain.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
        }

        public int CustomerId { get; set; }
        public string Name { get; set; } = null!;
        public int DefaultAddressId { get; set; }

        public virtual Address DefaultAddress { get; set; } = null!;
        public virtual ICollection<Order> Orders { get; set; }
    }
}
