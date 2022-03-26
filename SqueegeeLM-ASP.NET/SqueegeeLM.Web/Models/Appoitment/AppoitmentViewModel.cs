namespace SqueegeeLM.Web.Models.Appoitment
{
    public class AppoitmentViewModel
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public int CustomerId { get; set; }

        public bool IsBooked { get; set; }

        public ICollection<ServiceListViewModel> Services { get; set; }
    }
}
