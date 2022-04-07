namespace SqueegeeLM.Web.Models.Appoitment
{
    using SqueegeeLM.Data.Models;
    using System.ComponentModel.DataAnnotations;

    public class AppoitmentViewModel
    {
        public DateTime Date { get; set; }

        public int CustomerId { get; set; }

        [Display(Name = "Customer Name")]
        public Customer Customer { get; set; }

        public bool IsBooked { get; set; }

        public List<ServiceListViewModel> Services { get; set; }
    }
}
