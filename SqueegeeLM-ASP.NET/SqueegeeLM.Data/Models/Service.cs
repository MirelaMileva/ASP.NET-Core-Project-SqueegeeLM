namespace SqueegeeLM.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Service
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public int CleaningCategoryId { get; set; }

        [ForeignKey(nameof(CleaningCategoryId))]
        public CleaningCategory CleaningCategory { get; set; }

        [Required]
        public int PropertyCategoryId { get; set; }

        [ForeignKey(nameof(PropertyCategoryId))]
        public PropertyCategory PropertyCategory { get; set; }

        [Required]
        public int FrequencyId { get; set; }

        [ForeignKey(nameof(FrequencyId))]
        public Frequency Frequency { get; set; }
    }
}