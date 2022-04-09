namespace SqueegeeLM.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Appoitment
    {
        public Appoitment()
        {
            this.Id = Guid.NewGuid();
            this.Services = new List<Service>();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public int CustomerId { get; set; }

        [ForeignKey(nameof(CustomerId))]
        public Customer Customer { get; set; }

        public bool IsBooked { get; set; }

        public List<Service> Services { get; set; }
    }
}
