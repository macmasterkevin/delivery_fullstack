using System;
using System.Collections.Generic;

namespace DeliveryDevil.Domain.Models
{
    public partial class Address
    {
        public Address()
        {
            Customers = new HashSet<Customer>();
            Orders = new HashSet<Order>();
            Restaurants = new HashSet<Restaurant>();
        }

        public int AddressId { get; set; }
        public string Address1 { get; set; } = null!;
        public string City { get; set; } = null!;
        public int RegionId { get; set; }
        public string PostalCode { get; set; } = null!;

        public virtual Region Region { get; set; } = null!;
        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Restaurant> Restaurants { get; set; }
    }
}
