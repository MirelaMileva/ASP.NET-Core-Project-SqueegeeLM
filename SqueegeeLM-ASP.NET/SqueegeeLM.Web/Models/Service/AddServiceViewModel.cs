namespace SqueegeeLM.Web.Models.Service
{
    using SqueegeeLM.Data.Models.Enums;
    using System.ComponentModel.DataAnnotations;

    public class AddServiceViewModel
    {
        [Display(Name = "Cleaning Category")]
        public int CleaningCategoryId { get; set; }
        public IEnumerable<CleaningCategoryServiceModel> CleaningCategories { get; set; }

        [Display(Name = "Cleaning Type")]
        public CleaningType CleaningType { get; set; }

        [Display(Name = "Property")]
        public int PropertyCategoryId { get; set; }

        public IEnumerable<PropertyCategoryServiceModel> PropertyCategories { get; set; }

        [Display(Name = "Frequency")]
        public int FrequencyId { get; set; }

        public IEnumerable<FrequencyServiceModel> Frequency { get; set; }
    }
}
