namespace SqueegeeLM.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static DataConstants;

    public class Frequency
    {
        public Frequency()
        {
            this.Services = new List<Service>();
        }

        [Key]
        public int Id { get; set; }

        [StringLength(FrequencyNameMaxLength)]
        public string Name { get; set; }

        public ICollection<Service> Services { get; set; }
    }
}
