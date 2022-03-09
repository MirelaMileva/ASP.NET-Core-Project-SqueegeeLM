namespace SqueegeeLM.Web.Data
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    using SqueegeeLM.Data.Models;

    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Appoitment> Appoitments { get; set; }

        public DbSet<Area> Areas { get; set; }
        public DbSet<Service> Services { get; set; }

        public DbSet<Frequency> Frequencies { get; set; }

        public DbSet<Review> Reviews { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<Service>()
                .Property(p => p.Price)
                .HasColumnType("decimal(18,2)");

            builder.Entity<Customer>()
                .HasOne(c => c.Area)
                .WithMany(c => c.Customers)
                .HasForeignKey(c => c.AreaId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);
        }
    }
}