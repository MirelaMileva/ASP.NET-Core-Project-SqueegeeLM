namespace SqueegeeLM.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using SqueegeeLM.Services.Contracts;
    using SqueegeeLM.Web.Extensions;
    using SqueegeeLM.Web.Models.Address;

    public class AddressController : BaseController
    {
        private readonly IAddressService addressService;
        private readonly ICustomerService customerService;

        public AddressController(IAddressService addressService, ICustomerService customerService)
        {
            this.addressService = addressService;
            this.customerService = customerService;
        }

        public ActionResult AddAddress()
        {
            var userId = this.User.GetId();
            var customerId = this.customerService.GetCustomerId(userId);

            if (!this.customerService.UserIsCustomer(userId))
            {
                return RedirectToAction(nameof(CustomerController.Create), "Customer");
            }

            return View();
        }

        [HttpPost]
        public IActionResult AddAddress(AddAddressViewModel model)
        {
            var userId = this.User.GetId();

            var customer = this.customerService.GetCustomerId(userId);

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var address = this.addressService.CreateAddress
                (
                    model.Country,
                    model.CityName,
                    model.PostCode,
                    model.BuildingNumber,
                    model.Street,
                    customer
                );

            this.addressService.AddAddressToCustomer(customer, address);

            return RedirectToAction("UserAppoitments", "Appoitment");
        }
    }
}
