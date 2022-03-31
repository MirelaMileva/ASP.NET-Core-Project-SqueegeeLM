namespace SqueegeeLM.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using SqueegeeLM.Services.Contracts;

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

        //[HttpPost]
        //[Authorize]
        //public IActionResult Create(BecomeCustomerViewModel model)
        //{
        //    var userExist = this.service.UserIsCustomer();

        //    if (userExist)
        //    {
        //        return BadRequest();
        //    }

        //    if (!ModelState.IsValid)
        //    {
        //        return View(model);
        //    }
        //}
    }
}
