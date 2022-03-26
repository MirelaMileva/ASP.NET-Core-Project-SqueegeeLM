namespace SqueegeeLM.Services.Contracts
{
    using SqueegeeLM.Services.Models;
    using SqueegeeLM.Web.Models.Service;

    public interface IServiceService
    {
        void AddService(AddServiceServiceModel model);

        IEnumerable<CleaningCategoryServiceModel> GetCleaningCategories();

        IEnumerable<PropertyCategoryServiceModel> GetPropertyCategories();

        IEnumerable<FrequencyServiceModel> GetFrequencies();
    }
}
