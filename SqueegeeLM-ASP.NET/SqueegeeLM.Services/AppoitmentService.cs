﻿namespace SqueegeeLM.Services
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using SqueegeeLM.Data.Models;
    using SqueegeeLM.Services.Contracts;
    using SqueegeeLM.Services.Models.Appoitment;
    using SqueegeeLM.Services.Models.Appoitments;
    using SqueegeeLM.Web.Data;
    using System.Linq;

    public class AppoitmentService : IAppoitmentService
    {
        private readonly SqueegeeLMDbContext data;
        private readonly ICustomerService customerService;
        private readonly IMapper mapper;

        public AppoitmentService(
            SqueegeeLMDbContext data,
            ICustomerService customerService,
            IMapper mapper)
        {
            this.data = data;
            this.customerService = customerService;
            this.mapper = mapper;
        }

        public string AddAppoitment(int customerId, DateTime date)
        {
            var customer = this.customerService.GetCustomer(customerId);

            var appoitment = new Appoitment
            {
                Date = date,
                CustomerId = customerId
            };

            this.data.Appoitments.Add(appoitment);
            this.data.SaveChanges();

            return appoitment.Id.ToString();
        }

        public void AddServiceToCustomerAppoitment(int customerId, Service service)
        {
            var customer = this.customerService.GetCustomer(customerId);

            var appoitment = this.data
                .Appoitments
                .Where(c => c.CustomerId == customer.Id)
                .FirstOrDefault();

            appoitment.Services.Add(service);

            this.data.SaveChanges();
        }

        public Appoitment GetAppoitmentId(int customerId)
        {
            var appoitment = this.data.Appoitments
                .Where(a => a.CustomerId == customerId)
                .FirstOrDefault();

            return appoitment;
        }

        public IEnumerable<ServiceListServiceModel> GetAllServices(string userId)
        {
            var customerId = this.customerService.GetCustomerId(userId);

            return this.data
                .Services
                .Where(s => s.CustomerId == customerId)
                .ProjectTo<ServiceListServiceModel>(this.mapper.ConfigurationProvider)
                .ToList();
        }

        public AppoitmentQueryServiceModel AllAppoitments(
            string userId,
            int currentPage = 1,
            int appoitmentsPerPage = int.MaxValue)
        {
            var customerId = this.customerService.GetCustomerId(userId);
            var customer = this.customerService.GetCustomer(customerId);

            var appoitmentsQuery = this.data.Appoitments.Where(a => a.Customer.UserId == userId);

            var totalAppoitments = appoitmentsQuery.Count();

            var appoitments = GetAppoitments(appoitmentsQuery
                .Skip((currentPage - 1) * appoitmentsPerPage)
                .Take(appoitmentsPerPage));

            return new AppoitmentQueryServiceModel
            {
                TotalAppoitments = totalAppoitments,
                CurrentPage = currentPage,
                AppoitmentsPerPages = appoitmentsPerPage,
                Appoitments = appoitments
            };
        }

        public IEnumerable<AppoitmentServiceModel> GetAppoitments(IQueryable<Appoitment> appoitmentQuery)
        {
            return appoitmentQuery
                .ProjectTo<AppoitmentServiceModel>(this.mapper.ConfigurationProvider)
                .ToList();
        }

        public IEnumerable<AppoitmentServiceModel> AppoitmentsByUser(string userId)
        {
            var customerId = this.customerService.GetCustomerId(userId);
            var customer = this.customerService.GetCustomer(customerId);

            return this.data
                .Appoitments
                .Where(a => a.Customer.UserId == userId)
                .Select(a => new AppoitmentServiceModel
                {
                    CustomerId = a.CustomerId,
                    Customer = customer,
                    Date = a.Date,
                    Services = a.Services.Select(s => new ServiceListServiceModel
                    {
                        CleaningCategory = s.CleaningCategory.Name,
                        PropertyCategory = s.PropertyCategory.Name,
                        Frequency = s.Frequency.Name,
                        CleaningType = s.CleaningType,
                        CustomerId = customerId
                    }).ToList()
                }).ToList();
        }

        public bool EditAppoitment(string appoitmentId, int customerId, DateTime date)
        {
            var appoitmentData = GetAppoitmentId(customerId);

            if (appoitmentData == null)
            {
                return false;
            }

            if (appoitmentData.CustomerId != customerId)
            {
                return false;
            }

            appoitmentData.Date = date;

            this.data.SaveChanges();

            return true;
        }

        public void DeleteAppoitment(string userId)
        {
            var customerId = this.customerService.GetCustomerId(userId);
            var appoitment = GetAppoitmentId(customerId);

            if (appoitment == null)
            {
                return;
            }

            this.data.Appoitments.Remove(appoitment);
            this.data.SaveChanges();
        }

        public bool EditAppoitmentServices(string appoitmentId, int customerId, ServiceListServiceModel services)
        {
            var appoitment = this.data.Appoitments.Find(appoitmentId);
            var service = this.data.Services.Find(customerId);

            if (appoitment == null)
            {
                return false;
            }

            if (service == null)
            {
                return false;
            }

            if (appoitment.CustomerId != customerId && service.CustomerId != customerId)
            {
                return false;
            }

            service.CleaningCategory.Name = services.CleaningCategory;
            service.PropertyCategory.Name = services.PropertyCategory;
            service.Frequency.Name = services.Frequency;
            service.CleaningType = services.CleaningType;

            this.data.SaveChanges();

            return true;
        }

        public AppoitmentServiceModel Details(string appId, string userId)
        {
            var customerId = this.customerService.GetCustomerId(userId);
            var customer = this.customerService.GetCustomer(customerId);

            return this.data
                .Appoitments
                .Where(a => a.Id.ToString() == appId)
                .ProjectTo<AppoitmentServiceModel>(this.mapper.ConfigurationProvider)
                //.Select(a => new AppoitmentServiceModel
                //{
                //    Date = a.Date,
                //    CustomerId = a.CustomerId,
                //    Customer = customer
                //})
                .FirstOrDefault();
        }
    }
}
