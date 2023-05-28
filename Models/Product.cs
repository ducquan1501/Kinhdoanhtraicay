using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Kinhdoanhtraicay.Models
{
    public partial class Product
    {
        public Product()
        {
            CartItems = new HashSet<CartItem>();
            OrderDetails = new HashSet<OrderDetail>();
            ProductCategoryRelationships = new HashSet<ProductCategoryRelationship>();
            ProductReviews = new HashSet<ProductReview>();
        }
        [DisplayName("Mã sản phẩm")]
        public int? ProductId { get; set; } 
        [DisplayName("Tên")]
        public string Name { get; set; } = null!;
        [DisplayName("Mô tả")]
        public string Description { get; set; } = null!;
        [DisplayName("Giá")]
        public decimal Price { get; set; }
        [DisplayName("Số lượng")]
        public int StockQuantity { get; set; }
        [DisplayName("Hình ảnh")]
        public string? Image { get; set; }

        public virtual ICollection<CartItem> CartItems { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ICollection<ProductCategoryRelationship> ProductCategoryRelationships { get; set; }
        public virtual ICollection<ProductReview> ProductReviews { get; set; }
    }
}
