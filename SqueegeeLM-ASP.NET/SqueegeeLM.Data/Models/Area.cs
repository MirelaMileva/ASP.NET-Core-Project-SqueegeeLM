namespace SqueegeeLM.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static DataConstants;

    public class Area
    {
        public Area()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Customers = new List<Customer>();
        }

        [Key]
        [MaxLength(IdMaxLength)]
        public string Id { get; set; }

        [Required]
        [MaxLength(AreaPostCodeMaxLength)]
        public string PostCode { get; set; }

        public ICollection<Customer> Customers { get; set; }
    }
}