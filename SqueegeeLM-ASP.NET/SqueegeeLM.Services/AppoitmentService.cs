namespace SqueegeeLM.Services
{
    using SqueegeeLM.Services.Contracts;
    using SqueegeeLM.Web.Data;

    public class AppoitmentService : IAppoitmentService
    {
        private readonly SqueegeeLMDbContext data;

        public AppoitmentService(SqueegeeLMDbContext data)
        {
            this.data = data;
        }
    }
}
