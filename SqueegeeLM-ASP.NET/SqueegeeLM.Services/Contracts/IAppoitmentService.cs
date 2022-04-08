namespace SqueegeeLM.Services.Contracts
{
    using SqueegeeLM.Data.Models;
    using SqueegeeLM.Services.Models.Appoitment;

    public interface IAppoitmentService
    {
        //string AddAppoitment(int customerId, DateTime date, bool isBooked, IEnumerable<ServiceListServiceModel> service);

        IEnumerable<ServiceListServiceModel> GetAllServices();
       
    }
}
