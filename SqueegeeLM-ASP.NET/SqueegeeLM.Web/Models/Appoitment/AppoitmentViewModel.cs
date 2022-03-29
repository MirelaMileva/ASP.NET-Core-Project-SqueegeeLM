namespace SqueegeeLM.Web.Models.Appoitment
{
    using SqueegeeLM.Data.Models;

    public class AppoitmentViewModel
    {
        public DateTime Date { get; set; }

        public int CustomerId { get; set; }

        public Customer Customer { get; set; }

        public bool IsBooked { get; set; }

        public ICollection<ServiceListViewModel> Services { get; set; }
    }
}
