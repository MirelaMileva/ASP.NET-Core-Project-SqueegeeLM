namespace SqueegeeLM.Web.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    using SqueegeeLM.Data.Models;

    public class SqueegeeLMDbContext : IdentityDbContext<User>
    {
        public SqueegeeLMDbContext(DbContextOptions<SqueegeeLMDbContext> options)
            : base(options)
        {
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Appoitment> Appoitments { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<CleaningCategory> CleaningCategories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Frequency> Frequencies { get; set; }
        public DbSet<PropertyCategory> PropertyCategories { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Service> Services { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Customer>()
                .HasOne<User>()
                .WithOne()
                .HasForeignKey<Customer>(c => c.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Appoitment>()
                .HasOne(a => a.Customer)
                .WithMany(a => a.Appoitments)
                .HasForeignKey(a => a.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Review>()
                .HasOne(r => r.Customer)
                .WithMany(r => r.Reviews)
                .HasForeignKey(r => r.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Service>()
                .HasOne(s => s.CleaningCategory)
                .WithMany(s => s.Services)
                .HasForeignKey(s => s.CleaningCategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Service>()
                .HasOne(s => s.PropertyCategory)
                .WithMany(s => s.Services)
                .HasForeignKey(s => s.PropertyCategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Service>()
                .HasOne(s => s.Frequency)
                .WithMany(s => s.Services)
                .HasForeignKey(s => s.FrequencyId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);
        }
    }
}