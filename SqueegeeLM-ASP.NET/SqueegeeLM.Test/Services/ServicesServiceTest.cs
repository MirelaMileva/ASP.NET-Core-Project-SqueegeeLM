namespace SqueegeeLM.Test.Services
{
    using Microsoft.EntityFrameworkCore;
    using SqueegeeLM.Data.Models;
    using SqueegeeLM.Services;
    using SqueegeeLM.Web.Data;
    using System;
    using System.Linq;
    using Xunit;

    public class ServicesServiceTest
    {
        [Fact]
        public void AddServiceShouldReturnTrueWhenServiceIsCreated()
        {
            var options = new DbContextOptionsBuilder<SqueegeeLMDbContext>()
                .UseInMemoryDatabase(databaseName: "Service_AddService_Database")
                .Options;

            var dbContext = new SqueegeeLMDbContext(options);

            var servicesService = new ServiceService(dbContext, null);

            var service = new Service
            {
                Id = System.Guid.Empty,
                CleaningCategoryId = 1,
                PropertyCategoryId = 2,
                FrequencyId = 1,
                CleaningType = "Outside",
                CustomerId = 1
            };

            dbContext.Services.Add(service);
            dbContext.SaveChanges();

            var result = servicesService.AddService(service.CleaningCategoryId, 
                        service.PropertyCategoryId, 
                        service.FrequencyId,
                        service.CleaningType,
                        service.CustomerId);

            Assert.Equal(1, service.CleaningCategoryId);
            Assert.Equal(2, service.PropertyCategoryId);
            Assert.Equal(1, service.FrequencyId);
            Assert.Equal("Outside", service.CleaningType);
            Assert.Equal(1, service.CustomerId);
        }

        [Fact]
        public void AddServiceToAppoitmentShouldReturnTrueWhenServiceIsAdded()
        {
            var options = new DbContextOptionsBuilder<SqueegeeLMDbContext>()
                .UseInMemoryDatabase(databaseName: "Service_AddServiceToAppoitment_Database")
                .Options;

            var dbContext = new SqueegeeLMDbContext(options);

            var appoitment = new Appoitment
            {
                Id = System.Guid.Empty,
                CustomerId = 1,
                Date = DateTime.Now
            };

            dbContext.Appoitments.Add(appoitment);
            dbContext.SaveChanges();

            var appoitmentService = new AppoitmentService(dbContext, null);

            var servicesService = new ServiceService(dbContext, appoitmentService);

            var service = new Service
            {
                Id = System.Guid.Empty,
                CleaningCategoryId = 1,
                PropertyCategoryId = 2,
                FrequencyId = 1,
                CleaningType = "Outside",
                CustomerId = 1
            };

            dbContext.Services.Add(service);
            dbContext.SaveChanges();

            servicesService.AddServiceToAppoitment(appoitment.CustomerId, service);

            var appoitmentData = dbContext.Appoitments
                    .FirstOrDefault(a => a.Id == appoitment.Id)
                    .Services
                    .FirstOrDefault();

            Assert.Equal(service.CleaningCategoryId, appoitmentData.CleaningCategoryId);
            Assert.Equal(service.PropertyCategoryId, appoitmentData.PropertyCategoryId);
            Assert.Equal(service.FrequencyId, appoitmentData.FrequencyId);
            Assert.Equal(service.CleaningType, appoitmentData.CleaningType);
            Assert.Equal(service.CustomerId, appoitmentData.CustomerId);
        }

        [Fact]
        public void GetCleaningCategoriesShouldReturnTrueWhenCategoriesAreCorrect()
        {
            var options = new DbContextOptionsBuilder<SqueegeeLMDbContext>()
                .UseInMemoryDatabase(databaseName: "Service_GetCleaningCategories_Database")
                .Options;

            var dbContext = new SqueegeeLMDbContext(options);

            var servicesService = new ServiceService(dbContext, null);

            var cleaningCategory = new CleaningCategory
            {
                Id = 1,
                Name = "WindowsCleaning"
            };

            var cleaningCategory2 = new CleaningCategory
            {
                Id = 2,
                Name = "CommercialCleaning"
            };

            var cleaningCategory3 = new CleaningCategory
            {
                Id = 3,
                Name = "GutterCleaning"
            };

            dbContext.CleaningCategories.Add(cleaningCategory);
            dbContext.CleaningCategories.Add(cleaningCategory2);
            dbContext.CleaningCategories.Add(cleaningCategory3);
            dbContext.SaveChanges();

            var result = servicesService.GetCleaningCategories().ToList();

            Assert.Equal(3, result.Count);
        }

        [Fact]
        public void GetPropertyCategoriesShouldReturnTrueWhenCategoriesAreCorrect()
        {
            var options = new DbContextOptionsBuilder<SqueegeeLMDbContext>()
                .UseInMemoryDatabase(databaseName: "Service_GetPropertyCategories_Database")
                .Options;

            var dbContext = new SqueegeeLMDbContext(options);

            var servicesService = new ServiceService(dbContext, null);

            var propertyCategory = new PropertyCategory
            {
                Id = 1,
                Name = "Flat"
            };

            var propertyCategory2 = new PropertyCategory
            {
                Id = 2,
                Name = "House"
            };

            var propertyCategory3 = new PropertyCategory
            {
                Id = 3,
                Name = "Offices"
            };

            dbContext.PropertyCategories.Add(propertyCategory);
            dbContext.PropertyCategories.Add(propertyCategory2);
            dbContext.PropertyCategories.Add(propertyCategory3);
            dbContext.SaveChanges();

            var result = servicesService.GetPropertyCategories().ToList();

            Assert.Equal(3, result.Count);
        }

        [Fact]
        public void GetFrequenciesCategoriesShouldReturnTrueWhenCategoriesAreCorrect()
        {
            var options = new DbContextOptionsBuilder<SqueegeeLMDbContext>()
                .UseInMemoryDatabase(databaseName: "Service_GetFrequenciesCategories_Database")
                .Options;

            var dbContext = new SqueegeeLMDbContext(options);

            var servicesService = new ServiceService(dbContext, null);

            var frequency = new Frequency
            {
                Id = 1,
                Name = "OnceOnly"
            };

            var frequency2 = new Frequency
            {
                Id = 2,
                Name = "Monthly"
            };

            var frequency3 = new Frequency
            {
                Id = 3,
                Name = "TwiceYear"
            };

            dbContext.Frequencies.Add(frequency);
            dbContext.Frequencies.Add(frequency2);
            dbContext.Frequencies.Add(frequency3);
            dbContext.SaveChanges();

            var result = servicesService.GetFrequencies().ToList();

            Assert.Equal(3, result.Count);
        }
    }
}
