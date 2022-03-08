namespace SqueegeeLM.Data.Models
{
    using SqueegeeLM.Data.Models.Enum;
    using System.ComponentModel.DataAnnotations;

    using static DataConstants;

    public class Service
    {
        public Service()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Key]
        [MaxLength(IdMaxLength)]
        public string Id { get; set; }

        public CleaningType CleaningType { get; set; }

        public PropertyType PropertyType { get; set; }

        [Required]
        [Range(0.01, 100.00)]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
    }
}