namespace SqueegeeLM.Data.Models
{
    using SqueegeeLM.Data.Models.Enums;
    using System.ComponentModel.DataAnnotations;

    using static DataConstants;

    public class CleaningCategory
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(CleaningNameMaxLength)]
        public string Name { get; set; }

        [Required]
        public CleaningType CleaningType { get; set; }
    }
}
