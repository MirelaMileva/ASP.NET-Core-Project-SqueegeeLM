namespace SqueegeeLM.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static DataConstants;

    public class CleaningCategory
    {
        public CleaningCategory()
        {
            this.Services = new List<Service>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(CleaningNameMaxLength)]
        public string Name { get; set; }

        public ICollection<Service> Services { get; set; }
    }
}
