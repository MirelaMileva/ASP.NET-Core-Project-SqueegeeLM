namespace SqueegeeLM.Web.Controllers
{
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using SqueegeeLM.Services.Contracts;
    using SqueegeeLM.Web.Extensions;
    using SqueegeeLM.Web.Models.Service;

    public class ServiceController : BaseController
    {
        private readonly IServiceService service;
        private readonly ICustomerService customerService;
        private readonly IAppoitmentService appoitmentService;
        private readonly IMapper mapper;

        public ServiceController(
            IServiceService service, 
            ICustomerService customerService,
            IAppoitmentService appoitmentService,
            IMapper mapper)
        {
            this.service = service;
            this.customerService = customerService;
            this.appoitmentService = appoitmentService;
            this.mapper = mapper;
        }

        public IActionResult AddService()
        {
            var userId = this.User.GetId();

            if (!UserIsCustomer(userId))
            {
                return RedirectToAction("Create", "Customer");
            }

            return View(new AddServiceViewModel
               {
                   CleaningCategories = this.service.GetCleaningCategories(),
                   PropertyCategories = this.service.GetPropertyCategories(),
                   Frequency = this.service.GetFrequencies()
               });
        }

        [HttpPost]
        public IActionResult AddService(AddServiceViewModel model)
        {
            var userId = this.User.GetId();

            var customerId = this.customerService.GetCustomerId(userId);

            if (GetCustomerId(userId) == 0)
            {
                return RedirectToAction("Create", "Customer");
            }

            if (!this.service.CleaningCategoryExists(model.CleaningCategoryId))
            {
                this.ModelState.AddModelError(nameof(model.CleaningCategoryId), "Cleaning Category does not exist.");
            }

            if (!this.service.PropertyCategoryExists(model.PropertyCategoryId))
            {
                this.ModelState.AddModelError(nameof(model.PropertyCategoryId), "Property Category does not exist.");
            }

            if (!this.service.FrequencyExists(model.FrequencyId))
            {
                this.ModelState.AddModelError(nameof(model.FrequencyId), "Frequency does not exist.");
            }

            if (!ModelState.IsValid)
            {
                model.CleaningCategories = this.service.GetCleaningCategories();
                model.PropertyCategories = this.service.GetPropertyCategories();
                model.Frequency = this.service.GetFrequencies();

                return View(model);
            }

            var createService = this.service.AddService(
                model.CleaningCategoryId,
                model.PropertyCategoryId,
                model.FrequencyId,
                model.CleaningType,
                customerId);

            var appoitment = this.appoitmentService.GetAppoitmentId(customerId);

            this.service.AddServiceToAppoitment(customerId, createService);

            return RedirectToAction("AddAddress", "Address");
        }

        private int GetCustomerId(string userId)
            => this.customerService.GetCustomerId(userId);

        private bool UserIsCustomer(string userId)
            => this.customerService.UserIsCustomer(userId);

    }
}
