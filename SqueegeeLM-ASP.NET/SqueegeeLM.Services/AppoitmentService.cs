namespace SqueegeeLM.Services
{
    using SqueegeeLM.Data.Models;
    using SqueegeeLM.Services.Contracts;
    using SqueegeeLM.Services.Models.Appoitment;
    using SqueegeeLM.Services.Models.Appoitments;
    using SqueegeeLM.Web.Data;

    public class AppoitmentService : IAppoitmentService
    {
        private readonly SqueegeeLMDbContext data;

        public AppoitmentService(SqueegeeLMDbContext data)
        {
            this.data = data;
        }

        public void AddAppoitment(AppoitmentServiceModel model)
        {
            var appoitment = new Appoitment
            {
                Date = model.Date,
                CustomerId = model.CustomerId,
                IsBooked = model.IsBooked,
                //Services = 
            };
        }

        //public ServiceListServiceModel GetAllServices()
        //{

        //}
    }
}
