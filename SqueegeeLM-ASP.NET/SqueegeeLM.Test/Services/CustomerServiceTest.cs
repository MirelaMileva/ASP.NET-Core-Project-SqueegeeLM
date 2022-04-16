namespace SqueegeeLM.Test.Services
{
    using Microsoft.EntityFrameworkCore;
    using SqueegeeLM.Data.Models;
    using SqueegeeLM.Services;
    using SqueegeeLM.Web.Data;
    using Xunit;

    public class CustomerServiceTest
    {
        [Fact]
        public void UserIsCustomerShouldReturnTrueWhenUserIdIsCorrect()
        {
            var options = new DbContextOptionsBuilder<SqueegeeLMDbContext>()
                .UseInMemoryDatabase(databaseName: "Customer_UserIsCustomer_Database")
                .Options;

            var dbContext = new SqueegeeLMDbContext(options);

            var customerService = new CustomerService(dbContext);

            var customer = new Customer
            {
                Id = 1,
                FirstName = "Pesho",
                LastName = "Petrov",
                PhoneNumber = "07961287166",
                UserId = "user1"
            };

            dbContext.Customers.Add(customer);
            dbContext.SaveChanges();

            var result = customerService.UserIsCustomer(customer.UserId);

            Assert.True(result);
        }

        [Fact]
        public void GetCustomerIdShouldReturnTrueWhenUserIdIsCorrect()
        {
            var options = new DbContextOptionsBuilder<SqueegeeLMDbContext>()
                .UseInMemoryDatabase(databaseName: "Customer_GetCustomerId_Database")
                .Options;

            var dbContext = new SqueegeeLMDbContext(options);

            var customerService = new CustomerService(dbContext);

            var customer = new Customer
            {
                Id = 1,
                FirstName = "Pesho",
                LastName = "Petrov",
                PhoneNumber = "07961287166",
                UserId = "user1"
            };

            dbContext.Customers.Add(customer);
            dbContext.SaveChanges();

            var result = customerService.GetCustomerId(customer.UserId);

            Assert.Equal(customer.Id, result);
        }

        [Fact]
        public void GetCustomerShouldReturnTrueWhenCustomerIdIsCorrect()
        {
            var options = new DbContextOptionsBuilder<SqueegeeLMDbContext>()
                .UseInMemoryDatabase(databaseName: "Customer_GetCustomer_Database")
                .Options;

            var dbContext = new SqueegeeLMDbContext(options);

            var customerService = new CustomerService(dbContext);

            var customer = new Customer
            {
                Id = 1,
                FirstName = "Pesho",
                LastName = "Petrov",
                PhoneNumber = "07961287166",
                UserId = "user1"
            };

            dbContext.Customers.Add(customer);
            dbContext.SaveChanges();

            var result = customerService.GetCustomer(customer.Id);

            Assert.Equal(customer, result);
        }

        [Fact]
        public void BecomeCustomerShouldReturnTrueWhenCustomerIsCreated()
        {
            var options = new DbContextOptionsBuilder<SqueegeeLMDbContext>()
                .UseInMemoryDatabase(databaseName: "Customer_BecomeCustomer_Database")
                .Options;

            var dbContext = new SqueegeeLMDbContext(options);

            var customerService = new CustomerService(dbContext);

            var customer = new Customer
            {
                Id = 1,
                FirstName = "Pesho",
                LastName = "Petrov",
                PhoneNumber = "07961287166",
                UserId = "user1"
            };

            dbContext.Customers.Add(customer);
            dbContext.SaveChanges();

            var result = customerService.GetCustomer(customer.Id);

            Assert.Equal(1, customer.Id);
            Assert.Equal("Pesho", customer.FirstName);
            Assert.Equal("Petrov", customer.LastName);
            Assert.Equal("07961287166", customer.PhoneNumber);
            Assert.Equal("user1", customer.UserId);
        }
    }
}
