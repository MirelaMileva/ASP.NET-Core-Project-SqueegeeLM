namespace SqueegeeLM.Services.Contracts
{
    using SqueegeeLM.Data.Models;
    using SqueegeeLM.Web.Models.Service;

    public interface IServiceService
    {
        Service AddService(
            int cleaningCategoryId,
            int propertyCategoryId,
            int frequencyId,
            string cleaningType);

        void AddServiceToAppoitment(int customerId, Service service);

        IEnumerable<CleaningCategoryServiceModel> GetCleaningCategories();

        bool CleaningCategoryExists(int cleaningCategoryId);

        IEnumerable<PropertyCategoryServiceModel> GetPropertyCategories();

        bool PropertyCategoryExists(int properyCategoryId);

        IEnumerable<FrequencyServiceModel> GetFrequencies();

        bool FrequencyExists(int frequencyId);
    }
}
