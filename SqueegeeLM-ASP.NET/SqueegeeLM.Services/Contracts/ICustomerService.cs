namespace SqueegeeLM.Services.Contracts
{
    using SqueegeeLM.Web.Models.Customer;

    public interface ICustomerService
    {
        void BecomeCustomer(BecomeCustomerServiceModel model);

        //bool UserIsCustomer();
    }
}
