using System;
using System.Collections.Generic;

namespace DeliveryDevil.Domain.Models
{
    public partial class Region
    {
        public Region()
        {
            Addresses = new HashSet<Address>();
        }

        public int RegionId { get; set; }
        public int CountryId { get; set; }
        public string Name { get; set; } = null!;

        public virtual Country Country { get; set; } = null!;
        public virtual ICollection<Address> Addresses { get; set; }
    }
}
