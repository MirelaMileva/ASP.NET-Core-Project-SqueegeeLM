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

        [HttpPost]
        public IActionResult Add(AddAddressViewModel model)
        {
            var userId = this.User.GetId();

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
                    model.Street
                );

            var customer = this.customerService.GetCustomerUserId(userId);

            this.addressService.AddAddressToCustomer(customer, address);

            return RedirectToAction("Index", "Home");
        }
    }
}
