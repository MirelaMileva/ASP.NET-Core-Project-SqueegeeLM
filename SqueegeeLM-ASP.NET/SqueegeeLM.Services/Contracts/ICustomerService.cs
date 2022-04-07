namespace SqueegeeLM.Services.Contracts
{
    public interface ICustomerService
    {
        int BecomeCustomer(string firstName, string lastName, string phoneNumber, string userId);

        bool UserIsCustomer(string userId);

        int GetCustomerId(string userId);
    }
}
