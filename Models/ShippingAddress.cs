using System;
using System.Collections.Generic;

namespace Kinhdoanhtraicay.Models
{
    public partial class ShippingAddress
    {
        public int AddressId { get; set; }
        public int CustomerId { get; set; }
        public string FullName { get; set; } = null!;
        public string AddressLine1 { get; set; } = null!;
        public string? AddressLine2 { get; set; }
        public string City { get; set; } = null!;
        public string State { get; set; } = null!;
        public string Country { get; set; } = null!;
        public string PostalCode { get; set; } = null!;

        public virtual Customer Customer { get; set; } = null!;
    }
}
