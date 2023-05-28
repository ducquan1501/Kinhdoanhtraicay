using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Kinhdoanhtraicay.Models
{
    public partial class QLTCContext : DbContext
    {
        public QLTCContext()
        {
        }

        public QLTCContext(DbContextOptions<QLTCContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cart> Carts { get; set; } = null!;
        public virtual DbSet<CartItem> CartItems { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<News> News { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<OrderDetail> OrderDetails { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<ProductCategory> ProductCategories { get; set; } = null!;
        public virtual DbSet<ProductCategoryRelationship> ProductCategoryRelationships { get; set; } = null!;
        public virtual DbSet<ProductReview> ProductReviews { get; set; } = null!;
        public virtual DbSet<ShippingAddress> ShippingAddresses { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-PQETMFJ\\NGUYENDUCQUAN;Database = QLTC;Integrated Security = True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cart>(entity =>
            {
                entity.ToTable("carts");

                entity.Property(e => e.CartId)
                    .ValueGeneratedNever()
                    .HasColumnName("cart_id");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("created_date");

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Carts)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__carts__customer___4D94879B");
            });

            modelBuilder.Entity<CartItem>(entity =>
            {
                entity.ToTable("cart_items");

                entity.Property(e => e.CartItemId)
                    .ValueGeneratedNever()
                    .HasColumnName("cart_item_id");

                entity.Property(e => e.CartId).HasColumnName("cart_id");

                entity.Property(e => e.Price)
                    .HasColumnType("int")
                    .HasColumnName("price");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.HasOne(d => d.Cart)
                    .WithMany(p => p.CartItems)
                    .HasForeignKey(d => d.CartId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__cart_item__cart___5070F446");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.CartItems)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__cart_item__produ__5165187F");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("customers");

                entity.HasIndex(e => e.Email, "UQ__customer__AB6E61641C08ECB4")
                    .IsUnique();

                entity.Property(e => e.CustomerId)
                    .ValueGeneratedNever()
                    .HasColumnName("customer_id");

                entity.Property(e => e.Address)
                    .HasMaxLength(100)
                    .IsUnicode(true)
                    .HasColumnName("address");

                entity.Property(e => e.Country)
                    .HasMaxLength(50)
                    .IsUnicode(true)
                    .HasColumnName("country");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("('2023-05-01 00:00:00')");

                entity.Property(e => e.CustomerName)
                    .HasMaxLength(50)
                    .IsUnicode(true)
                    .HasColumnName("customer_name");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("phone_number");

                entity.Property(e => e.State)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("state");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("('2023-05-01 00:00:00')");
            });

            modelBuilder.Entity<News>(entity =>
            {
                entity.ToTable("news");

                entity.Property(e => e.NewsId)
                    .ValueGeneratedNever()
                    .HasColumnName("news_id");

                entity.Property(e => e.Content)
                    .HasColumnType("text")
                    .HasColumnName("content");

                entity.Property(e => e.PublishDate)
                    .HasColumnType("datetime")
                    .HasColumnName("publish_date");

                entity.Property(e => e.Title)
                    .HasMaxLength(100)
                    .IsUnicode(true)
                    .HasColumnName("title");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("orders");

                entity.Property(e => e.OrderId)
                    .ValueGeneratedNever()
                    .HasColumnName("order_id");

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.OrderDate)
                    .HasColumnType("datetime")
                    .HasColumnName("order_date");

                entity.Property(e => e.TotalPrice)
                    .HasColumnType("int")
                    .HasColumnName("total_price");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__orders__customer__403A8C7D");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.ToTable("order_details");

                entity.Property(e => e.OrderDetailId)
                    .ValueGeneratedNever()
                    .HasColumnName("order_detail_id");

                entity.Property(e => e.OrderId).HasColumnName("order_id");

                entity.Property(e => e.Price)
                    .HasColumnType("int")
                    .HasColumnName("price");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__order_det__order__4316F928");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__order_det__produ__440B1D61");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("products");

                entity.Property(e => e.ProductId)
                    .ValueGeneratedNever()
                    .HasColumnName("product_id");

                entity.Property(e => e.Description)
                    .HasColumnType("text")
                    .HasColumnName("description");

                entity.Property(e => e.Image)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Price)
                    .HasColumnType("int")
                    .HasColumnName("price");

                entity.Property(e => e.StockQuantity).HasColumnName("stock_quantity");
            });

            modelBuilder.Entity<ProductCategory>(entity =>
            {
                entity.HasKey(e => e.CategoryId)
                    .HasName("PK__product___D54EE9B457EA4A96");

                entity.ToTable("product_categories");

                entity.Property(e => e.CategoryId)
                    .ValueGeneratedNever()
                    .HasColumnName("category_id");

                entity.Property(e => e.Description)
                    .HasColumnType("text")
                    .HasColumnName("description");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<ProductCategoryRelationship>(entity =>
            {
                entity.HasKey(e => e.RelationshipId)
                    .HasName("PK__product___C0CFD5546AAFF5FD");

                entity.ToTable("product_category_relationships");

                entity.Property(e => e.RelationshipId)
                    .ValueGeneratedNever()
                    .HasColumnName("relationship_id");

                entity.Property(e => e.CategoryId).HasColumnName("category_id");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.ProductCategoryRelationships)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__product_c__categ__5535A963");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductCategoryRelationships)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__product_c__produ__5441852A");
            });

            modelBuilder.Entity<ProductReview>(entity =>
            {
                entity.HasKey(e => e.ReviewId)
                    .HasName("PK__product___60883D90ADDCEC47");

                entity.ToTable("product_reviews");

                entity.Property(e => e.ReviewId)
                    .ValueGeneratedNever()
                    .HasColumnName("review_id");

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.Rating).HasColumnName("rating");

                entity.Property(e => e.ReviewDate)
                    .HasColumnType("datetime")
                    .HasColumnName("review_date");

                entity.Property(e => e.ReviewText)
                    .HasColumnType("text")
                    .HasColumnName("review_text");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.ProductReviews)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__product_r__custo__4AB81AF0");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductReviews)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__product_r__produ__49C3F6B7");
            });

            modelBuilder.Entity<ShippingAddress>(entity =>
            {
                entity.HasKey(e => e.AddressId)
                    .HasName("PK__shipping__CAA247C804ABC3A8");

                entity.ToTable("shipping_addresses");

                entity.Property(e => e.AddressId)
                    .ValueGeneratedNever()
                    .HasColumnName("address_id");

                entity.Property(e => e.AddressLine1)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("address_line_1");

                entity.Property(e => e.AddressLine2)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("address_line_2");

                entity.Property(e => e.City)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("city");

                entity.Property(e => e.Country)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("country");

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.FullName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("full_name");

                entity.Property(e => e.PostalCode)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("postal_code");

                entity.Property(e => e.State)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("state");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.ShippingAddresses)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__shipping___custo__46E78A0C");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
