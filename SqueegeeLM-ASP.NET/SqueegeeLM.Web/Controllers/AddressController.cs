namespace SqueegeeLM.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using SqueegeeLM.Services.Contracts;
    using SqueegeeLM.Web.Models.Address;

    public class AddressController : BaseController
    {
        private readonly IAddressService addressService;

        public AddressController(IAddressService addressService)
        {
            this.addressService = addressService;
        }

        [HttpPost]
        public IActionResult Add(AddAddressViewModel model)
        {
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

            return RedirectToAction("Index", "Home");
        }
    }
}
