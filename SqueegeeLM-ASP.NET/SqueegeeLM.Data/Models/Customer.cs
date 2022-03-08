namespace SqueegeeLM.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static DataConstants;

    public class Customer
    {
        public Customer()
        {
            this.Id = Guid.NewGuid().ToString();
            this.CustomerAppoitments = new List<Appoitment>();
        }

        [Key]
        [MaxLength(IdMaxLength)]
        public string Id { get; set; }

        [Required]
        [MaxLength(CustomerFirstNameMaxLength)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(CustomerLastNameMaxLength)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(CustomerEmailMaxLength)]
        public string Email { get; set; }

        [Required]
        [MaxLength(CustomerAddressMaxLength)]
        public string Address { get; set; }

        [Required]
        [MaxLength(CustomerPhoneMaxLength)]
        public int PhoneNumber { get; set; }

        public string AreaId { get; set; }

        [ForeignKey(nameof(AreaId))]
        public Area Area { get; set; }

        public ICollection<Appoitment> CustomerAppoitments { get; set; }
    }
}
