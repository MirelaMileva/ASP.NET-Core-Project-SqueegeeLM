namespace SqueegeeLM.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static DataConstants;

    public class PropertyCategory
    {
        public PropertyCategory()
        {
            this.Services = new List<Service>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(PropertyNameMaxLength)]
        public string Name { get; set; }

        public ICollection<Service> Services { get; set; }
    }
}
