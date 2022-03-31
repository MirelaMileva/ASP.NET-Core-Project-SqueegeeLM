namespace SqueegeeLM.Services
{
    using SqueegeeLM.Data.Models;
    using SqueegeeLM.Services.Contracts;
    using SqueegeeLM.Services.Models.Appoitment;
    using SqueegeeLM.Services.Models.Appoitments;
    using SqueegeeLM.Web.Data;

    public class AppoitmentService : IAppoitmentService
    {
        private readonly SqueegeeLMDbContext data;

        public AppoitmentService(SqueegeeLMDbContext data)
        {
            this.data = data;
        }

        public void AddAppoitment(AppoitmentServiceModel model)
        {
            var services = this.data.Services;

            var appoitment = new Appoitment
            {
                Date = model.Date,
                CustomerId = model.CustomerId,
                IsBooked = model.IsBooked,
                Services = services
            };

            this.data.Appoitments.Add(appoitment);
            this.data.SaveChanges();
        }

        public List<ServiceListServiceModel> GetAllServices()
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
