namespace SqueegeeLM.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using SqueegeeLM.Services.Contracts;
    using SqueegeeLM.Web.Extensions;
    using SqueegeeLM.Web.Models.Customer;

    public class CustomerController : Controller
    {
        private readonly ICustomerService customerService;

        public CustomerController(ICustomerService customerService) 
            => this.customerService = customerService;

        [Authorize]
        public IActionResult Create() => View();

        [HttpPost]
        [Authorize]
        public IActionResult Create(BecomeCustomerViewModel model)
        {
            var userId = this.User.GetId();

            var userExist = this.customerService.UserIsCustomer(userId);

            if (userExist)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var customerId = this.customerService.BecomeCustomer(
                model.FirstName,
                model.LastName,
                model.PhoneNumber,
                userId);

            return RedirectToAction("Index", "Home");
        }
    }
}
