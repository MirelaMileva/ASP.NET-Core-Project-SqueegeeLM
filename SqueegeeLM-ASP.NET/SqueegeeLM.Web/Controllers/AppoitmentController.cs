namespace SqueegeeLM.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using SqueegeeLM.Services.Contracts;
    using SqueegeeLM.Web.Extensions;
    using SqueegeeLM.Web.Models.Appoitment;

    public class AppoitmentController : Controller
    {
        private readonly IAppoitmentService appoitmentService;
        private readonly IServiceService serviceService;
        private readonly ICustomerService customerService;

        public AppoitmentController(
            IAppoitmentService appoitmentService, 
            IServiceService serviceService,
            ICustomerService customerService)
        {
            this.appoitmentService = appoitmentService;
            this.serviceService = serviceService;
            this.customerService = customerService;
        }

        public IActionResult AddAppoitment()
        {
            var userId = this.User.GetId();
            var customerUserId = this.customerService.GetCustomerUserId(userId);

            if (!this.customerService.UserIsCustomer(userId))
            {
                return RedirectToAction(nameof(CustomerController.Create), "Customer");
            }

            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult AddAppoitment(AppoitmentViewModel model)
        {
            var userId = this.User.GetId();

            var customerId = this.customerService.GetCustomerUserId(userId);

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var createAppoitment = this.appoitmentService.AddAppoitment(
                customerId,
                model.Date
                );

            return RedirectToAction("AddService", "Service");
        }

        [Authorize]
        public IActionResult UserAppoitments()
        {
            var appoitments = this.appoitmentService.AppoitmentsByUser(this.User.GetId());

            return View(appoitments);
        }

        [Authorize]
        public IActionResult Edit(string id)
        {
            var userId = this.User.GetId();
            var customerUserId = this.customerService.GetCustomerUserId(userId);

            if (!this.customerService.UserIsCustomer(userId))
            {
                return RedirectToAction(nameof(CustomerController.Create), "Customer");
            }

            var appoitment = this.appoitmentService.Details(id);

            if(appoitment.CustomerId == customerUserId)
            {
                return BadRequest();
            }

            return View(new AppoitmentViewModel
            {
                Id = id,
                CustomerId = customerUserId,
                Date = appoitment.Date,
                Services = appoitment.Services.Select(s => new ServiceListViewModel
                {
                    CleaningCategories = s.CleaningCategory,
                    PropertyCategories = s.PropertyCategory,
                    Frequency = s.Frequency,
                    CleaningType = s.CleaningType
                })
            });
        }

        [HttpPost]
        [Authorize]
        public IActionResult Edit(string id, AppoitmentViewModel appoitmentData)
        {
            var userId = this.User.GetId();

            var customerUserId = this.customerService.GetCustomerUserId(userId);

            if (!this.customerService.UserIsCustomer(userId))
            {
                return RedirectToAction(nameof(CustomerController.Create), "Customer");
            }

            if(!ModelState.IsValid)
            {
                return View(appoitmentData);
            }

            var appoitmentId = this.appoitmentService.GetAppoitmentId(customerUserId);

            //var editAppoitment = this.appoitmentService.EditAppoitment(
            //    appoitmentId,
            //    customerUserId);
            //    //appoitment.IsBooked);

            return RedirectToAction(nameof(UserAppoitments));
        }
    }
}
