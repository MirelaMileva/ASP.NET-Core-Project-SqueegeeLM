namespace SqueegeeLM.Services.Contracts
{
    using SqueegeeLM.Data.Models;
    using SqueegeeLM.Services.Models.Appoitment;
    using SqueegeeLM.Services.Models.Appoitments;

    public interface IAppoitmentService
    {
        string AddAppoitment(int customerId, DateTime date, bool isBooked);

        IEnumerable<ServiceListServiceModel> GetAllServices();

        public Appoitment GetAppoitmentId(int customerId);

        IEnumerable<AppoitmentServiceModel> AppoitmentsByUser(string userId);

        AppoitmentServiceModel Details(string id);
    }
}
