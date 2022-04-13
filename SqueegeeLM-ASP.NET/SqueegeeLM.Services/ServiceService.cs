namespace SqueegeeLM.Services
{
    using SqueegeeLM.Data.Models;
    using SqueegeeLM.Services.Contracts;
    using SqueegeeLM.Web.Data;
    using SqueegeeLM.Web.Models.Service;
    using System.Collections.Generic;

    public class ServiceService : IServiceService
    {
        private readonly SqueegeeLMDbContext data;
        private readonly IAppoitmentService appoitmentService;

        public ServiceService(SqueegeeLMDbContext data, IAppoitmentService appoitmentService)
        {
            this.data = data;
            this.appoitmentService = appoitmentService;
        }

        public Service AddService(int cleaningCategoryId,  
                 int propertyCategoryId, 
                 int frequencyId, 
                 string cleaningType,
                 int customerId)
        {
            var serviceData = new Service
            {
                CleaningCategoryId = cleaningCategoryId,
                PropertyCategoryId = propertyCategoryId,
                FrequencyId = frequencyId,
                CleaningType = cleaningType,
                CustomerId = customerId
            };

            this.data.Services.Add(serviceData);
            this.data.SaveChanges();

            return serviceData;
        }
        public void AddServiceToAppoitment(int customerId, Service service)
        {
            var appoitment = this.appoitmentService.GetAppoitmentId(customerId);

            appoitment.Services.Add(service);

            this.data.SaveChanges();
        }

        public IEnumerable<CleaningCategoryServiceModel> GetCleaningCategories()
        {
            return this.data
                .CleaningCategories
                .Select(c => new CleaningCategoryServiceModel
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToList();
        }

        public bool CleaningCategoryExists(int cleaningCategoryId)
            => this.data.CleaningCategories.Any(c => c.Id == cleaningCategoryId);

        public IEnumerable<FrequencyServiceModel> GetFrequencies()
        {
            return this.data
               .Frequencies
               .Select(c => new FrequencyServiceModel
               {
                   Id = c.Id,
                   Name = c.Name
               })
               .ToList();
        }

        public bool FrequencyExists(int frequencyId)
            => this.data.Frequencies.Any(c => c.Id == frequencyId);

        public IEnumerable<PropertyCategoryServiceModel> GetPropertyCategories()
        {
            return this.data
               .PropertyCategories
               .Select(c => new PropertyCategoryServiceModel
               {
                   Id = c.Id,
                   Name = c.Name
               })
               .ToList();
        }

        public bool PropertyCategoryExists(int propertyCategoryId)
    => this.data.PropertyCategories.Any(c => c.Id == propertyCategoryId);
    }
}
