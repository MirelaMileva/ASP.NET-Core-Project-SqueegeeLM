namespace SqueegeeLM.Services.Contracts
{
    using SqueegeeLM.Services.Models.Appoitment;
    using SqueegeeLM.Services.Models.Appoitments;

    public interface IAppoitmentService
    {
        void AddAppoitment(AppoitmentServiceModel model);

        //ServiceListServiceModel GetAllServices();
    }
}
