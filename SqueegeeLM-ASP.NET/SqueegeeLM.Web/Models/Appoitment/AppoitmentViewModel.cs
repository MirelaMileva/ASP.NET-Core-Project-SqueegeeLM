namespace SqueegeeLM.Web.Models.Appoitment
{
    using SqueegeeLM.Data.Models;
    using System.ComponentModel.DataAnnotations;

    public class AppoitmentViewModel
    {
        public string Id { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }

        [Required]
        public int CustomerId { get; set; }

        [Display(Name = "Customer Name")]
        [Required]
        public Customer Customer { get; set; }

        public bool IsBooked { get; set; }

        public IEnumerable<ServiceListViewModel> Services { get; set; }
    }
}
