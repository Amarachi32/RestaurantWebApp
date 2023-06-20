
using Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Domain.DbContext
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions option) : base(option)
        {}

        public DbSet<Category>Categories { get; set; }
        public DbSet<Product>Products { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<ShoppingItem> ShoppingItems { get; set; }
        public DbSet<Cart>Carts { get; set; }
        public DbSet<Order>Orders { get; set; }
        public DbSet<Contact>Contacts { get; set; }
        public DbSet<Payment>Payments { get; set; }
        public DbSet<GalleryImage> GalleryImages { get; set; }
        public DbSet<ImageTag> ImageTags { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("trojantrading");
            modelBuilder.Entity<User>()
                .ToTable("user")
                .HasKey(u => u.UserId);
            modelBuilder.Entity<Product>()
                .ToTable("product")
                .HasKey(p => p.ProductId);
            modelBuilder.Entity<Order>()
                .ToTable("order")
                .HasKey(o => o.OrderId);
            modelBuilder.Entity<ShoppingCart>()
                .ToTable("shoppingCart")
                .HasKey(s => s.CartId);
            modelBuilder.Entity<ShoppingItem>()
                .ToTable("shoppingItem")
                .HasKey(s => s.ItemId);
           /* modelBuilder.Entity<PdfBoard>()
                .ToTable("pdfBoard")
                .HasKey(p => p.Id);
            modelBuilder.Entity<HeadInformation>()
                .ToTable("headInformation")
                .HasKey(h => h.Id);*/
            modelBuilder.Entity<PackagingList>()
                .ToTable("packagingList")
                .HasKey(h => h.Id);

            //user shoppingcart 1:m
            modelBuilder.Entity<User>()
                .HasMany(u => u.ShoppingCarts)
                .WithOne(s => s.User)
                .HasForeignKey(s => s.UserId);

            //order shoppingcart 1:1
            modelBuilder.Entity<ShoppingCart>()
                .HasOne(s => s.Order)
                .WithOne(o => o.ShoppingCart)
                .HasForeignKey<Order>(o => o.ShoppingCartId)
                .OnDelete(DeleteBehavior.Restrict);

            //shopping Cart Shopping Item 1:m
            modelBuilder.Entity<ShoppingItem>()
                .HasOne(s => s.ShoppingCart)
                .WithMany(s => s.ShoppingItems)
                .HasForeignKey(s => s.ShoppingCartId)
                .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
