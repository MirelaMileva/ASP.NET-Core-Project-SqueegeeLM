namespace SqueegeeLM.Services.Models.Appoitments
{
    using SqueegeeLM.Data.Models;
    using SqueegeeLM.Services.Models.Appoitment;

    public class AppoitmentServiceModel
    {
        public string Id { get; set; }

        public DateTime Date { get; set; }

        public int CustomerId { get; set; }

        public Customer Customer { get; set; }

        public List<ServiceListServiceModel> Services { get; set; }
    }
}
