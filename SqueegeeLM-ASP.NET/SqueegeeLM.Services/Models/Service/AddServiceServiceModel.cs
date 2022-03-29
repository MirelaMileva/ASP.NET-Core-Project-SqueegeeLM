namespace SqueegeeLM.Services.Models.Service
{
    using SqueegeeLM.Data.Models.Enums;
    using SqueegeeLM.Web.Models.Service;

    public class AddServiceServiceModel
    {
        public int CleaningCategoryId { get; set; }

        public IEnumerable<CleaningCategoryServiceModel> CleaningCategories { get; set; }

        public CleaningType CleaningType { get; set; }

        public int PropertyCategoryId { get; set; }

        public IEnumerable<PropertyCategoryServiceModel> PropertyCategories { get; set; }

        public int FrequencyId { get; set; }

        public IEnumerable<FrequencyServiceModel> Frequency { get; set; }
    }
}
