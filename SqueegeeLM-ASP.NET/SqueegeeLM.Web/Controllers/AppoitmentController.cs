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
            var customerUserId = this.customerService.GetCustomerId(userId);

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

            var customerId = this.customerService.GetCustomerId(userId);

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
        public IActionResult UserServices()
        {
            var userId = User.GetId();

            var appServices = this.appoitmentService.GetAllServices(userId);

            return View(appServices);
        }

        public IActionResult AllAppoitments([FromQuery] AllAppoitmentsQueryModel appoitmentsQuery)
        {
            var userId = User.GetId();

            var appoitments = this.appoitmentService
                .AllAppoitments(
                userId,
                appoitmentsQuery.CurrentPage,
                AllAppoitmentsQueryModel.AppoitmentsPerPage
                );

            appoitmentsQuery.TotalAppoitments = appoitments.TotalAppoitments;
            //appoitmentsQuery.Appoitments = appoitments.Appoitments.Select(a => new );

            return View(appoitmentsQuery);
        }

        [Authorize]
        public IActionResult Edit(string appId)
        {
            var userId = this.User.GetId();
            var customerId = this.customerService.GetCustomerId(userId);
            var customer = this.customerService.GetCustomer(customerId);

            var appoitmentData = this.appoitmentService.GetAppoitmentId(customerId);

            if (!this.customerService.UserIsCustomer(userId))
            {
                return RedirectToAction(nameof(CustomerController.Create), "Customer");
            }

            var appoitment = this.appoitmentService.Details(appoitmentData.Id.ToString(), userId);

            if (appoitment.CustomerId != customerId)
            {
                return BadRequest();
            }

            return View(new AppoitmentViewModel
            {
                Id = appId,
                CustomerId = customerId,
                Date = appoitment.Date
            });
        }

        [HttpPost]
        [Authorize]
        public IActionResult Edit(string id, AppoitmentViewModel appoitmentData)
        {
            var userId = this.User.GetId();

            var customerUserId = this.customerService.GetCustomerId(userId);

            if (!this.customerService.UserIsCustomer(userId))
            {
                return RedirectToAction(nameof(CustomerController.Create), "Customer");
            }

            if(!ModelState.IsValid)
            {
                return View(appoitmentData);
            }

            var appoitmentId = this.appoitmentService.GetAppoitmentId(customerUserId).ToString();

            var editAppoitment = this.appoitmentService.EditAppoitment(
                appoitmentId,
                customerUserId,
                appoitmentData.Date);

            return RedirectToAction(nameof(UserAppoitments));
        }

        [HttpPost]
        [Authorize]
        public IActionResult Delete()
        {
            var userId = this.User.GetId();

            var customerId = this.customerService.GetCustomerId(userId);

            var appoitmentData = this.appoitmentService.GetAppoitmentId(customerId);

            if (!this.customerService.UserIsCustomer(userId))
            {
                return RedirectToAction(nameof(CustomerController.Create), "Customer");
            }

            if (appoitmentData.CustomerId != customerId)
            {
                return BadRequest();
            }

            this.appoitmentService.DeleteAppoitment(userId);

            return RedirectToAction("UserAppoitments", "Appoitment");
        }
    }
}
