using System;
using System.Collections.Generic;

namespace Kinhdoanhtraicay.Models
{
    public partial class Cart
    {
        public Cart()
        {
            CartItems = new HashSet<CartItem>();
        }

        public int CartId { get; set; }
        public int CustomerId { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual Customer Customer { get; set; } = null!;
        public virtual ICollection<CartItem> CartItems { get; set; }
    }
}
