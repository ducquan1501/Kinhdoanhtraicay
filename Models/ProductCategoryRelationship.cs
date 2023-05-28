using System;
using System.Collections.Generic;

namespace Kinhdoanhtraicay.Models
{
    public partial class ProductCategoryRelationship
    {
        public int RelationshipId { get; set; }
        public int ProductId { get; set; }
        public int CategoryId { get; set; }

        public virtual ProductCategory Category { get; set; } = null!;
        public virtual Product Product { get; set; } = null!;
    }
}
