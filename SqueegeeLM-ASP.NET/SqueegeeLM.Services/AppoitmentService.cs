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
        private readonly ICustomerService customerService;

        public AppoitmentService(SqueegeeLMDbContext data, ICustomerService customerService)
        {
            this.data = data;
            this.customerService = customerService;
        }

        public string AddAppoitment(int customerId, DateTime date, bool isBooked)
        {
            var appoitment = new Appoitment
            {
                Date = date,
                CustomerId = customerId,
                IsBooked = isBooked
            };

            this.data.Appoitments.Add(appoitment);
            this.data.SaveChanges();

            return appoitment.Id.ToString();
        }

        public Appoitment GetAppoitmentId(int customerId)
        {
            var appoitment = this.data.Appoitments
                .Where(a => a.CustomerId == customerId)
                .FirstOrDefault();

            return appoitment;
        }

        public IEnumerable<ServiceListServiceModel> GetAllServices()
        {
            return this.data
                .Services
                .Select(s => new ServiceListServiceModel
                {
                    CleaningType = s.CleaningType,
                    CleaningCategory = s.CleaningCategory.Name,
                    PropertyCategory = s.PropertyCategory.Name,
                    Frequency = s.Frequency.Name
                })
                .ToList();
        }

        public IEnumerable<AppoitmentServiceModel> AppoitmentsByUser(string userId)
        {
            return this.data
                .Appoitments
                .Where(a => a.Customer.UserId == userId)
                .Select(a => new AppoitmentServiceModel
                {
                    CustomerId = a.CustomerId,
                    Date = a.Date,
                    IsBooked = a.IsBooked,
                    Services = a.Services.Select(s => new ServiceListServiceModel
                    {
                        CleaningType = s.CleaningType,
                        CleaningCategory = s.CleaningCategory.Name,
                        PropertyCategory = s.PropertyCategory.Name,
                        Frequency = s.Frequency.Name
                    })
                });
        }

        public AppoitmentServiceModel Details(string id)
        {
            return this.data
                .Appoitments
                .Where(a => a.Id.ToString() == id)
                .Select(a => new AppoitmentServiceModel
                {
                    Date = a.Date,
                    CustomerId = a.CustomerId,
                    IsBooked = a.IsBooked,
                    Services = a.Services.Select(s => new ServiceListServiceModel
                    {
                        CleaningType = s.CleaningType,
                        CleaningCategory = s.CleaningCategory.Name,
                        PropertyCategory = s.PropertyCategory.Name,
                        Frequency = s.Frequency.Name
                    })
                })
                .FirstOrDefault();
        }
    }
}
