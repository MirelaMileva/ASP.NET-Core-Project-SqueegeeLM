namespace SqueegeeLM.Test.Services
{
    using Microsoft.EntityFrameworkCore;
    using SqueegeeLM.Data.Models;
    using SqueegeeLM.Services;
    using SqueegeeLM.Web.Data;
    using Xunit;

    public class CityServiceTest
    {
        [Fact]
        public void GetCitiesShouldReturnTrueWhenCityIsCreated()
        {
            var options = new DbContextOptionsBuilder<SqueegeeLMDbContext>()
                .UseInMemoryDatabase(databaseName: "City_CreateCity_Database")
                .Options;

            var dbContext = new SqueegeeLMDbContext(options);

            var cityService = new CityService(dbContext);

            var city = new City
            {
                Id = 1,
                Name = "Plovdiv",
                PostCode = "4000"
            };

            dbContext.Cities.Add(city);
            dbContext.SaveChanges();

            var result = cityService.CreateCity(city.Name, city.PostCode);

            Assert.Equal("Plovdiv", result.Name);
            Assert.Equal("4000", result.PostCode);
        }
    }
}
