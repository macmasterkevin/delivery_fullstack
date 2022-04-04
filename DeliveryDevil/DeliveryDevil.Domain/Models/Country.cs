using System;
using System.Collections.Generic;

namespace DeliveryDevil.Domain.Models
{
    public partial class Country
    {
        public Country()
        {
            Regions = new HashSet<Region>();
        }

        public int CountryId { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Region> Regions { get; set; }
    }
}
