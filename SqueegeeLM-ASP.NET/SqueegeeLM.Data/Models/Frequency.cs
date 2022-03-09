namespace SqueegeeLM.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static DataConstants;

    public class Frequency
    {
        [Key]
        public int Id { get; set; }

        [StringLength(FrequencyNameMaxLength)]
        public string Name { get; set; }
    }
}
