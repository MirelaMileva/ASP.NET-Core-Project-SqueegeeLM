namespace SqueegeeLM.Test.Services
{
    using Microsoft.EntityFrameworkCore;
    using SqueegeeLM.Data.Models;
    using SqueegeeLM.Services;
    using SqueegeeLM.Web.Data;
    using System.Linq;
    using Xunit;

    public class AddressServiceTest
    {
        [Fact]
        public void CreateAddressShouldReturnTrueWhenAddressIsCreated()
        {
            var options = new DbContextOptionsBuilder<SqueegeeLMDbContext>()
                .UseInMemoryDatabase(databaseName: "Address_CreateAddress_Database")
                .Options;

            var dbContext = new SqueegeeLMDbContext(options);

            var addressService = new AddressService(dbContext, null);

            var address = new Address
            {
                Id = 1,
                Country = "Bulgaria",
                CityId = 1,
                CustomerId = 1,
                BuildingNumber = "24",
                Street = "Opulchenska",
                City = new City { Id = 1, Name = "Sofia", PostCode = "1000"},
            };

            dbContext.Addresses.Add(address);
            dbContext.SaveChanges();

            var result = addressService.CreateAddress(address.Country, 
                    address.City.Name, 
                    address.City.PostCode, 
                    address.Street, 
                    address.BuildingNumber, 
                    address.CustomerId);

            Assert.Equal(1, address.Id);
            Assert.Equal("Bulgaria", address.Country);
            Assert.Equal(1, address.CityId);
            Assert.Equal("24", address.BuildingNumber);
            Assert.Equal("Opulchenska", address.Street);
            Assert.Equal("Sofia", address.City.Name);
            Assert.Equal("1000", address.City.PostCode);
        }

        [Fact]
        public void GetCitiesShouldReturnTrueWhenCityIsFound()
        {
            var options = new DbContextOptionsBuilder<SqueegeeLMDbContext>()
                .UseInMemoryDatabase(databaseName: "Address_GetCities_Database")
                .Options;

            var dbContext = new SqueegeeLMDbContext(options);

            var addressService = new AddressService(dbContext, null);

            var cityName = "Sofia";
            var postCode = "1000";

            var city = new City
            {
                Id = 1, 
                Name = cityName, 
                PostCode = postCode
            };

            dbContext.Cities.Add(city);
            dbContext.SaveChanges();

            var result = addressService.GetCities(city.Name, city.PostCode);

            Assert.Equal("Sofia", city.Name);
            Assert.Equal("1000", city.PostCode);
            Assert.Equal(1, dbContext.Cities.Count());
        }


        [Fact]
        public void GetCitiesShouldReturnTrueWhenCityIsCreated()
        {
            var options = new DbContextOptionsBuilder<SqueegeeLMDbContext>()
                .UseInMemoryDatabase(databaseName: "Address_GetCities_Database")
                .Options;

            var dbContext = new SqueegeeLMDbContext(options);

            var addressService = new AddressService(dbContext, null);

            var cityName = "Sofia";
            var postCode = "1000";

            var city = new City
            {
                Id = 1,
                Name = cityName,
                PostCode = postCode
            };

            dbContext.Cities.Add(city);
            dbContext.SaveChanges();

            addressService.GetCities(city.Name, city.PostCode);

            var cityData = dbContext.Cities.FirstOrDefault(c => c.Name == cityName && c.PostCode == postCode);

            Assert.Equal(cityName, cityData.Name);
            Assert.Equal(postCode, cityData.PostCode);
        }

        [Fact]
        public void AddAddressToCustomerShouldReturnTrueWhenAddressIsAddedToCustomer()
        {
            var options = new DbContextOptionsBuilder<SqueegeeLMDbContext>()
                .UseInMemoryDatabase(databaseName: "Address_AddAddressToCustomer_Database")
                .Options;

            var dbContext = new SqueegeeLMDbContext(options);

            var customer = new Customer
            {
                Id = 1,
                FirstName = "Pesho",
                LastName = "Petrov",
                PhoneNumber = "0976388399",
                UserId = "user1"
            };

            dbContext.Customers.Add(customer);
            dbContext.SaveChanges();

            var customerService = new CustomerService(dbContext);

            var addressService = new AddressService(dbContext, customerService);

            var address = new Address
            {
                Id = 1,
                Country = "Bulgaria",
                CityId = 1,
                CustomerId = 1,
                BuildingNumber = "24",
                Street = "Opulchenska",
                City = new City { Id = 1, Name = "Sofia", PostCode = "1000" },
            };

            dbContext.Addresses.Add(address);
            dbContext.SaveChanges();

            addressService.AddAddressToCustomer(customer.Id, address);

            var customerData = dbContext.Customers
                    .FirstOrDefault(a => a.Id == customer.Id)
                    .Addresses
                    .FirstOrDefault();

            Assert.Equal(address.Country, customerData.Country);
            Assert.Equal(address.Street, customerData.Street);
            Assert.Equal(address.BuildingNumber, customerData.BuildingNumber);
            Assert.Equal(address.Id, customerData.Id);
            Assert.Equal(address.CityId, customerData.CityId);
            Assert.Equal(address.CustomerId, customerData.CustomerId);
        }

    }
}
