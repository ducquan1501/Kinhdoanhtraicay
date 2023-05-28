using System;
using System.Collections.Generic;

namespace Kinhdoanhtraicay.Models
{
    public partial class ProductReview
    {
        public int ReviewId { get; set; }
        public int ProductId { get; set; }
        public int CustomerId { get; set; }
        public int Rating { get; set; }
        public string? ReviewText { get; set; }
        public DateTime ReviewDate { get; set; }

        public virtual Customer Customer { get; set; } = null!;
        public virtual Product Product { get; set; } = null!;
    }
}
