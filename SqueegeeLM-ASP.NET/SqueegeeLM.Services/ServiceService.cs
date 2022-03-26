namespace SqueegeeLM.Services
{
    using SqueegeeLM.Data.Models;
    using SqueegeeLM.Services.Contracts;
    using SqueegeeLM.Services.Models;
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

        public void AddService(AddServiceServiceModel model)
        {
            var service = new Service
            {
                CleaningCategoryId = model.CleaningCategoryId,
                PropertyCategoryId = model.PropertyCategoryId,
                FrequencyId = model.FrequencyId,
            };

            this.data.Services.Add(service);
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
