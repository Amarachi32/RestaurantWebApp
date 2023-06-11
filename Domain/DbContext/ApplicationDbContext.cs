
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
        public DbSet<Cart>Carts { get; set; }
        public DbSet<Order>Orders { get; set; }
        public DbSet<Contact>Contacts { get; set; }
        public DbSet<Payment>Payments { get; set; }
        public DbSet<GalleryImage> GalleryImages { get; set; }
        public DbSet<ImageTag> ImageTags { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
