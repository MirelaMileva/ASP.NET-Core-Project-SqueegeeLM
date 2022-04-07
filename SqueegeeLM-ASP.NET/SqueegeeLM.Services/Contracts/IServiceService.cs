namespace SqueegeeLM.Services.Contracts
{
    using SqueegeeLM.Data.Models;
    using SqueegeeLM.Web.Models.Service;

    public interface IServiceService
    {
        string AddService(
            int cleaningCategoryId,
            int propertyCategoryId,
            int frequencyId,
            string cleaningType);

        IEnumerable<CleaningCategoryServiceModel> GetCleaningCategories();

        IEnumerable<PropertyCategoryServiceModel> GetPropertyCategories();

        IEnumerable<FrequencyServiceModel> GetFrequencies();
    }
}
