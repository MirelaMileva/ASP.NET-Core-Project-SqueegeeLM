namespace SqueegeeLM.Web.Models.Service
{
    using System.ComponentModel.DataAnnotations;

    public class AddServiceViewModel
    {
        [Required]
        [Display(Name = "Cleaning Category")]
        public int CleaningCategoryId { get; set; }
        public IEnumerable<CleaningCategoryViewModel> CleaningCategories { get; set; }

        [Required]
        [Display(Name = "Property")]
        public int PropertyCategoryId { get; set; }

        public IEnumerable<PropertyCategoryViewModel> PropertyCategories { get; set; }

        [Required]
        [Display(Name = "Frequency")]
        public int FrequencyId { get; set; }

        public IEnumerable<FrequencyServiceViewModel> Frequency { get; set; }
    }
}
