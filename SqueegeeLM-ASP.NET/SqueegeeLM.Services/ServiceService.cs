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

        public ServiceService(SqueegeeLMDbContext data)
        {
            this.data = data;
        }

        public string AddService(int cleaningCategoryId,  
                 int propertyCategoryId, 
                 int frequencyId, 
                 string cleaningType)
        {
            var serviceData = new Service
            {
                CleaningCategoryId = cleaningCategoryId,
                PropertyCategoryId = propertyCategoryId,
                FrequencyId = frequencyId,
                CleaningType = cleaningType
            };

            this.data.Services.Add(serviceData);
            this.data.SaveChanges();

            return serviceData.Id.ToString();
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
    }
}
