namespace SqueegeeLM.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using SqueegeeLM.Services.Contracts;
    using SqueegeeLM.Web.Extensions;
    using SqueegeeLM.Web.Models.Customer;

    public class CustomerController : Controller
    {
        private readonly ICustomerService service;

        public CustomerController(ICustomerService service)
        {
            service = this.service;
        }

        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult Create(BecomeCustomerViewModel model)
        {
            var userId = this.User.GetId();

            //var userExist = this.service.UserIsCustomer(userId);

            //if (userExist)
            //{
            //    return BadRequest();
            //}

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var customerId = this.service.BecomeCustomer(
                model.FirstName,
                model.LastName,
                model.PhoneNumber,
                userId);

            return RedirectToAction("Index", "Home");
        }
    }
}
