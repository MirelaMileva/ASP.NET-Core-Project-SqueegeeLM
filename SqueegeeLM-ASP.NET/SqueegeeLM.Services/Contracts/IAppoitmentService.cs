namespace SqueegeeLM.Services.Contracts
{
    using SqueegeeLM.Data.Models;
    using SqueegeeLM.Services.Models.Appoitment;
    using SqueegeeLM.Services.Models.Appoitments;

    public interface IAppoitmentService
    {
        string AddAppoitment(int customerId, DateTime date);

        bool EditAppoitment(string appoitmentId, int customerId, DateTime date);

        bool EditAppoitmentServices(string appoitmentId, int customerId, ServiceListServiceModel services);

        void AddServiceToCustomerAppoitment(int customerId, Service service);

        IEnumerable<ServiceListServiceModel> GetAllServices();

        public Appoitment GetAppoitmentId(int customerId);

        //IEnumerable<Appoitment> AppoitmentsByUser(string userId);

        IEnumerable<AppoitmentServiceModel> AppoitmentsByUser(string userId);

        AppoitmentServiceModel Details(string id);
    }
}
