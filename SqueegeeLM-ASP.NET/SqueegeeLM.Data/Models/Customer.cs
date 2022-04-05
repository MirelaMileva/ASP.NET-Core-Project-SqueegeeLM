namespace SqueegeeLM.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static DataConstants;
    
    public class Customer
    {
        public Customer()
        {
            this.Appoitments = new List<Appoitment>();
            this.Reviews = new List<Review>();
            this.Addresses = new List<Address>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(CustomerFirstNameMaxLength)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(CustomerLastNameMaxLength)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(CustomerPhoneNumberMaxLength)]
        public string PhoneNumber { get; set; }

        [Required]
        public string UserId { get; set; }

        public ICollection<Address> Addresses { get; set; }

        public ICollection<Appoitment> Appoitments { get; set; }

        public ICollection<Review> Reviews { get; set; }
    }
}
