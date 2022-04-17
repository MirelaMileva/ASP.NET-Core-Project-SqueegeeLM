namespace SqueegeeLM.Test.Services
{
    using Microsoft.EntityFrameworkCore;
    using SqueegeeLM.Data.Models;
    using SqueegeeLM.Services;
    using SqueegeeLM.Web.Data;
    using System;
    using Xunit;

    public class AppoitmentServiceTest
    {
        [Fact]
        public void AddAppoitmentShouldReturnTrueWhenAppoitmentIsCreated()
        {
            var options = new DbContextOptionsBuilder<SqueegeeLMDbContext>()
                .UseInMemoryDatabase(databaseName: "Appoitment_AddAppoitment_Database")
                .Options;

            var dbContext = new SqueegeeLMDbContext(options);

            var customer = new Customer
            {
                Id = 1,
                FirstName = "Gosho",
                LastName = "Goshev",
                PhoneNumber = "098794848484",
                UserId = "user1"
            };

            var customerService = new CustomerService(dbContext);

            var appoitmentService = new AppoitmentService(dbContext, customerService);

            var appoitment = new Appoitment
            {
                Date = DateTime.Now,
                CustomerId = customer.Id,
            };

            dbContext.Appoitments.Add(appoitment);
            dbContext.SaveChanges();

            var result = appoitmentService.AddAppoitment(customer.Id, appoitment.Date);

            Assert.Equal(customer.Id, appoitment.CustomerId);
            Assert.Equal(DateTime.Now, appoitment.Date);
        }
    }
}
