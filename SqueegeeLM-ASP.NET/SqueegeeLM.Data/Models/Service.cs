namespace SqueegeeLM.Data.Models
{
    using SqueegeeLM.Data.Models.Enums;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Service
    {
        public Service()
        {
            this.Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

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

        public CleaningType CleaningType { get; set; }
    }
}