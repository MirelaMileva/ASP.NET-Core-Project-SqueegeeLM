namespace SqueegeeLM.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using static DataConstants;

    public class Review
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(ReviewNameMaxLength)]
        public string Name { get; set; }

        [Required]
        public int CustomerId { get; set; }

        [ForeignKey(nameof(CustomerId))]
        public Customer Customer { get; set; }

        [Required]
        [StringLength(ReviewDescriptionMaxLength)]
        public string Description { get; set; }
    }
}
