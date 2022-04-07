namespace SqueegeeLM.Services
{
    using SqueegeeLM.Data.Models;
    using SqueegeeLM.Services.Contracts;
    using SqueegeeLM.Web.Data;

    public class CityService : ICityService
    {
        private readonly SqueegeeLMDbContext data;

        public CityService(SqueegeeLMDbContext data)
        {
            this.data = data;
        }

        public City CreateCity(string name, string postCode)
        {
            var cityData = new City
            {
                Name = name,
                PostCode = postCode
            };

            this.data.Cities.Add(cityData);
            this.data.SaveChanges();

            return cityData;
        }
    }
}
