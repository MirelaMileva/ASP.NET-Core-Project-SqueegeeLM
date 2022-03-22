namespace SqueegeeLM.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static DataConstants;
    public class City
    {
        public City()
        {
            this.Addresses = new List<Address>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(CityNameMaxLength)]
        public string Name { get; set; }

        [Required]
        [MaxLength(PostCodeMaxLength)]
        public string PostCode { get; set; }

        public ICollection<Address> Addresses { get; set; }
    }
}
