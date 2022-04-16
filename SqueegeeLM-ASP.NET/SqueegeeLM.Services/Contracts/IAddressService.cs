namespace SqueegeeLM.Services.Contracts
{
    using SqueegeeLM.Data.Models;

    public interface IAddressService
    {
        Address CreateAddress(string country, string street, string buildingNumber, string cityName, string postCode, int customerId);

        void AddAddressToCustomer(int customerId, Address address);
    }
}
