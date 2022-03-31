namespace SqueegeeLM.Services.Models.Appoitments
{
    using SqueegeeLM.Services.Models.Appoitment;

    public class AppoitmentServiceModel
    {
        public int CustomerId { get; set; }

        public DateTime Date { get; set; }

        public bool IsBooked { get; set; }

        public List<ServiceListServiceModel> Services { get; set; }
    }
}
