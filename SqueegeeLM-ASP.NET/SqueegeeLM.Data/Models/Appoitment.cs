namespace SqueegeeLM.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using static DataConstants;

    public class Appoitment
    {
        public Appoitment()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Services = new List<Service>();
        }

        [Key]
        [MaxLength(IdMaxLength)]
        public string Id { get; set; }

        public DateTime Date { get; set; }

        [Required]
        public string CustomerId { get; set; }

        [ForeignKey(nameof(CustomerId))]
        public Customer Customer { get; set; }

        public bool IsBooked { get; set; }

        public ICollection<Service> Services { get; set; }
    }
}
