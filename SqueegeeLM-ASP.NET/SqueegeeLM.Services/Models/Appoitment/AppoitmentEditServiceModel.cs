namespace SqueegeeLM.Services.Models.Appoitment
{
    public class AppoitmentEditServiceModel
    {
        public string Id { get; set; }

        public DateTime Date { get; set; }

        public int CustomerId { get; set; }

        public int ServiceId { get; set; }
    }
}