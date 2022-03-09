namespace SqueegeeLM.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using static DataConstants;

    public class Customer
    {
        public Customer()
        {
            this.Appoitments = new List<Appoitment>();
            this.Reviews = new List<Review>();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(CustomerAddressMaxLength)]
        public string Address { get; set; }

        [Required]
        public Guid AreaId { get; set; }

        [ForeignKey(nameof(AreaId))]
        public Area Area { get; set; }

        public ICollection<Appoitment> Appoitments { get; set; }

        public ICollection<Review> Reviews { get; set; }
    }
}
