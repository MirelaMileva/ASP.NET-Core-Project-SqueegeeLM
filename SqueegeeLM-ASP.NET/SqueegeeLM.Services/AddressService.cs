namespace SqueegeeLM.Services
{
    using SqueegeeLM.Data.Models;
    using SqueegeeLM.Services.Contracts;
    using SqueegeeLM.Web.Data;

    public class AddressService : IAddressService
    {
        private readonly SqueegeeLMDbContext data;
        private readonly ICustomerService customerService;

        public AddressService(SqueegeeLMDbContext data, ICustomerService customerService)
        {
            this.data = data;
            this.customerService = customerService;
        }

        public void AddAddressToCustomer(int customerId, Address address)
        {
            var customer = this.customerService.GetCustomerId(customerId);

            customer.Addresses.Add(address);

            this.data.SaveChanges();
        }

        public Address CreateAddress(string country, string cityName, string postCode, string street, string buildingNumber, int customerId)
        {
            var city = this.GetCities(cityName, postCode); 

            var address = new Address
            {
                Country = country,
                City = city,
                Street = street,
                BuildingNumber = buildingNumber,
                CustomerId = customerId
            };

            this.data.Addresses.Add(address);
            this.data.SaveChanges();

            return address;
        }

        public City GetCities(string cityName, string postCode)
        {
            var city = this.data.Cities.FirstOrDefault(c => c.Name == cityName && c.PostCode == postCode);

            if(city == null)
            {
                city = new City
                {
                    Name = cityName,
                    PostCode = postCode
                };

                this.data.Cities.Add(city);
                this.data.SaveChanges();
            }

            return city;
        }

    }
}
