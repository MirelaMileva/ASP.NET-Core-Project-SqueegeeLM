namespace SqueegeeLM.Services
{
    using SqueegeeLM.Data.Models;
    using SqueegeeLM.Services.Contracts;
    using SqueegeeLM.Services.Models.Appoitment;
    using SqueegeeLM.Web.Data;

    public class AppoitmentService : IAppoitmentService
    {
        private readonly SqueegeeLMDbContext data;

        public AppoitmentService(SqueegeeLMDbContext data)
        {
            this.data = data;
        }

        public string AddAppoitment(int customerId, DateTime date, bool isBooked, IEnumerable<ServiceListServiceModel> service)
        {
            //var services = this.data.Services;

            var appoitment = new Appoitment
            {
                Date = date,
                CustomerId = customerId,
                IsBooked = isBooked,
                Services = service
            };

            this.data.Appoitments.Add(appoitment);
            this.data.SaveChanges();

            return appoitment.Id.ToString();
        }

        public IEnumerable<ServiceListServiceModel> GetAllServices()
        {
            return this.data
                .Services
                .Select(s => new ServiceListServiceModel
                {
                    CleaningCategory = s.CleaningCategory.ToString(),
                    PropertyCategory = s.PropertyCategory.ToString(),
                    Frequency = s.Frequency.ToString()
                })
                .ToList();
        }
    }
}
