namespace SqueegeeLM.Web.Extensions
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Identity;
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

            SeedAdministrator(services);

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

        private static void SeedAdministrator(IServiceProvider services)
        {
            var userManager = services.GetRequiredService<UserManager<User>>();
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

            Task
                .Run(async () =>
                {
                    if(await roleManager.RoleExistsAsync("Administrator"))
                    {
                        return;
                    }

                    var role = new IdentityRole { Name = "Administrator" };

                    await roleManager.CreateAsync(role);

                    const string adminEmail = "admin@squeegeelm.com";
                    const string adminPassword = "admin123";

                    var user = new User
                    {
                        Email = adminEmail,
                        UserName = adminEmail,
                    };

                    await userManager.CreateAsync(user, adminPassword);

                    await userManager.AddToRoleAsync(user, role.Name);
                })
                .GetAwaiter()
                .GetResult();
        }
    }
}
