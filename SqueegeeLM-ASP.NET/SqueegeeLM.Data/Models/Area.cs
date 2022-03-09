namespace SqueegeeLM.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static DataConstants;

    public class Area
    {
        public Area()
        {
            this.Id = Guid.NewGuid();
            this.Customers = new List<Customer>();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(AreaPostCodeMaxLength)]
        public string PostCode { get; set; }

        public ICollection<Customer> Customers { get; set; }
    }
}