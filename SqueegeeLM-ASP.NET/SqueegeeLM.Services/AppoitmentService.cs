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

        public string AddAppoitment(int customerId, DateTime date)
        {
            var customer = this.customerService.GetCustomerId(customerId);

            var appoitment = new Appoitment
            {
                Date = date,
                CustomerId = customerId
            };

            this.data.Appoitments.Add(appoitment);
            this.data.SaveChanges();

            return appoitment.Id.ToString();
        }

        public void AddServiceToCustomerAppoitment(int customerId, Service service)
        {    
            var customer = this.customerService.GetCustomerId(customerId);

            var appoitment = this.data
                .Appoitments
                .Where(c => c.CustomerId == customer.Id)
                .FirstOrDefault();

            appoitment.Services.Add(service);

            this.data.SaveChanges();
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
                    Services = a.Services.Select(s => new ServiceListServiceModel
                    {
                        CleaningType = s.CleaningType,
                        CleaningCategory = s.CleaningCategory.Name,
                        PropertyCategory = s.PropertyCategory.Name,
                        Frequency = s.Frequency.Name
                    })
                })
                .ToList();
        }

        public bool EditAppoitment(string appoitmentId, int customerId)
        {
            var appoitmentData = this.data.Appoitments.Find(appoitmentId);

            if (appoitmentData == null)
            {
                return false;
            }

            if(appoitmentData.CustomerId != customerId)
            {
                return false;
            }

            //appoitmentData.Date = appoitment.Date;
            //appoitmentData.Services = appoitment.Services.Select();

            this.data.SaveChanges();

            return true;
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
