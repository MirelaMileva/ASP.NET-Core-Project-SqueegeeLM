namespace SqueegeeLM.Services.Models.Appoitment
{
    using SqueegeeLM.Services.Models.Appoitments;

    public class AppoitmentQueryServiceModel
    {
        public int CurrentPage { get; set; }

        public int AppoitmentsPerPages { get; set; }

        public int TotalAppoitments { get; set; }

        public IEnumerable<AppoitmentServiceModel> Appoitments { get; set; }
    }
}
