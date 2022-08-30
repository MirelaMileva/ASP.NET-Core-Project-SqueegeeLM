namespace SqueegeeLM.Web.Models.Appoitment
{
    public class AllAppoitmentsQueryModel
    {
        public const int AppoitmentsPerPage = 3;

        public int CurrentPage { get; set; } = 1;

        public int TotalAppoitments { get; set; }

        public IEnumerable<AppoitmentViewModel> Appoitments { get; set; }
    }
}
