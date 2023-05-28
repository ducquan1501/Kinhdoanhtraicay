using System;
using System.Collections.Generic;

namespace Kinhdoanhtraicay.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Carts = new HashSet<Cart>();
            Orders = new HashSet<Order>();
            ProductReviews = new HashSet<ProductReview>();
            ShippingAddresses = new HashSet<ShippingAddress>();
        }

        public int CustomerId { get; set; }
        public string CustomerName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string State { get; set; } = null!;
        public string Country { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual ICollection<Cart> Carts { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<ProductReview> ProductReviews { get; set; }
        public virtual ICollection<ShippingAddress> ShippingAddresses { get; set; }
    }
}
