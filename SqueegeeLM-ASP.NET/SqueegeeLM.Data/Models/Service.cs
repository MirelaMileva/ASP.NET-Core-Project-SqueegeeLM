namespace SqueegeeLM.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Microsoft.EntityFrameworkCore;

    using SqueegeeLM.Data.Models.Enums;

    public class Service
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public CleaningType CleaningType { get; set; }

        [Required]
        public PropertyType PropertyType { get; set; }

        [Required]
        public int FrequencyId { get; set; }

        [ForeignKey(nameof(FrequencyId))]
        public Frequency Frequency { get; set; }

        [Required]
        [Range(0.01, 100.00)]
        [DataType(DataType.Currency)]
        [Precision(18, 2)]
        public decimal Price { get; set; }
    }
}