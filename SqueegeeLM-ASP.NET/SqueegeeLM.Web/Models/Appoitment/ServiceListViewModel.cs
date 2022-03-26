namespace SqueegeeLM.Web.Models.Appoitment
{
    using SqueegeeLM.Web.Models.Service;
    using System.ComponentModel.DataAnnotations;

    public class ServiceListViewModel
    {
        [Display(Name = "Cleaning Category")]
        public int CleaningCategoryId { get; set; }
        public IEnumerable<CleaningCategoryServiceModel> CleaningCategories { get; set; }

        [Display(Name = "Property")]
        public int PropertyCategoryId { get; set; }

        public IEnumerable<PropertyCategoryServiceModel> PropertyCategories { get; set; }

        [Display(Name = "Frequency")]
        public int FrequencyId { get; set; }

        public IEnumerable<FrequencyServiceModel> Frequency { get; set; }
    }
}
