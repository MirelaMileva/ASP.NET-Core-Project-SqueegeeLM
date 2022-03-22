namespace SqueegeeLM.Data
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Design;
    using Microsoft.Extensions.Configuration;

    using SqueegeeLM.Web.Data;

    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<SqueegeeLMDbContext>
    {
        public SqueegeeLMDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<SqueegeeLMDbContext>();
            
            optionsBuilder
                .UseSqlServer(configuration.GetConnectionString("DefaultConnection"));

            return new SqueegeeLMDbContext(optionsBuilder.Options);
        }
    }
}
