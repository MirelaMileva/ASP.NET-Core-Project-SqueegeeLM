namespace SqueegeeLM.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static DataConstants;
    public class PropertyCategory
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(PropertyNameMaxLength)]
        public string Name { get; set; }

        [Required]
        public int BedroomCount { get; set; }
    }
}
