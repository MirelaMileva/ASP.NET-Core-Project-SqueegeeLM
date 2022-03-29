namespace SqueegeeLM.Web.Extensions
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using SqueegeeLM.Data.Models;
    using SqueegeeLM.Web.Data;

    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder PrepareDatabase(this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();
            var services = serviceScope.ServiceProvider;

            MigrateDatabase(services);

            SeedCleaningCategories(services);
            SeedPropertyCategories(services);
            SeedFrequencies(services);

            return app;
        }

        private static void MigrateDatabase(IServiceProvider services)
        {
            var data = services.GetRequiredService<SqueegeeLMDbContext>();

            data.Database.Migrate();
        }

        private static void SeedCleaningCategories(IServiceProvider services)
        {
            var data = services.GetRequiredService<SqueegeeLMDbContext>();

            if (data.CleaningCategories.Any())
            {
                return;
            }

            data.CleaningCategories.AddRange(new[]
            {
                new CleaningCategory { Name = "WindowCleaning" },
                new CleaningCategory { Name = "ConservatoryCleaning" },
                new CleaningCategory { Name = "GutterCleaning" },
                new CleaningCategory { Name = "PatioDrivewayCleaning" },
                new CleaningCategory { Name = "CommercialWindowCleaning" },
            });

            data.SaveChanges();
        }

        private static void SeedPropertyCategories(IServiceProvider services)
        {
            var data = services.GetRequiredService<SqueegeeLMDbContext>();

            if (data.PropertyCategories.Any())
            {
                return;
            }

            data.PropertyCategories.AddRange(new[]
            {
                new PropertyCategory { Name = "Flat"},
                new PropertyCategory { Name = "Maisonette"},
                new PropertyCategory { Name = "House"},
                new PropertyCategory { Name = "ApartmentBlock"},
                new PropertyCategory { Name = "Offices"},
                new PropertyCategory { Name = "Shop"}
            });

            data.SaveChanges();
        }

        private static void SeedFrequencies(IServiceProvider services)
        {
            var data = services.GetRequiredService<SqueegeeLMDbContext>();

            if (data.Frequencies.Any())
            {
                return;
            }

            data.Frequencies.AddRange(new[]
            {
                new Frequency { Name = "Once Only"},
                new Frequency { Name = "Monthly"},
                new Frequency { Name = "Quarterly"},
                new Frequency { Name = "Twice Year"}
            });

            data.SaveChanges();
        }
    }
}
