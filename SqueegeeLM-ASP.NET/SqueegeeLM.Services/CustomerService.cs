namespace SqueegeeLM.Services
{
    using SqueegeeLM.Data.Models;
    using SqueegeeLM.Services.Contracts;
    using SqueegeeLM.Web.Data;
    using SqueegeeLM.Web.Models.Customer;

    public class CustomerService : ICustomerService
    {
        private readonly SqueegeeLMDbContext data;

        public CustomerService(SqueegeeLMDbContext data)
        {
            this.data = data;
        }

        public void BecomeCustomer(BecomeCustomerServiceModel model)
        {
            var customer = new Customer
            {
                FirstName = model.FirstName,
                LastName = model.LastName
            };

            this.data.Customers.Add(customer);
            this.data.SaveChanges();
        }

        //public bool UserIsCustomer()
        //    => !this.data
        //    .Customers
        //    .Any(c => c.UserId == this.User.GetId());
    }
}
