namespace SqueegeeLM.Services
{
    using SqueegeeLM.Data.Models;
    using SqueegeeLM.Services.Contracts;
    using SqueegeeLM.Web.Data;

    public class CustomerService : ICustomerService
    {
        private readonly SqueegeeLMDbContext data;

        public CustomerService(SqueegeeLMDbContext data)
        {
            this.data = data;
        }

        public int BecomeCustomer(string firstName, string lastName, string phoneNumber, string userId)
        {
            //var userId = this.data.Users.Find(ClaimTypes.NameIdentifier).Id;

            var customerData = new Customer
            {
                FirstName = firstName,
                LastName = lastName,
                PhoneNumber = phoneNumber,
                UserId = userId
        };

            this.data.Customers.Add(customerData);
            this.data.SaveChanges();

            return customerData.Id;
        }

        public bool UserIsCustomer(string userId)
            => this.data
                .Customers
                .Any(c => c.UserId == userId);

        public int GetCustomerId(string userId)
            => this.data
            .Customers
            .Where(c => c.UserId == userId)
            .Select(c => c.Id)
            .FirstOrDefault();
    }
}
