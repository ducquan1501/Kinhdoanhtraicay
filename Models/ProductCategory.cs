using System;
using System.Collections.Generic;

namespace Kinhdoanhtraicay.Models
{
    public partial class ProductCategory
    {
        public ProductCategory()
        {
            ProductCategoryRelationships = new HashSet<ProductCategoryRelationship>();
        }

        public int CategoryId { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }

        public virtual ICollection<ProductCategoryRelationship> ProductCategoryRelationships { get; set; }
    }
}
