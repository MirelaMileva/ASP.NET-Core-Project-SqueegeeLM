namespace SqueegeeLM.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using SqueegeeLM.Services.Contracts;
    using SqueegeeLM.Web.Models.Service;

    public class ServiceController : BaseController
    {
        private readonly IServiceService service;

        public ServiceController(IServiceService service)
        {
            this.service = service;
        }

        public IActionResult AddService()
        {
            //if (!this.service.UserIsCustomer)
            //{
            //    return RedirectToAction("Create", "Customer");
            //}

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
            if (!this.service.GetCleaningCategories().Any(m => m.Id == model.CleaningCategoryId))
            {
                this.ModelState.AddModelError(nameof(model.CleaningCategoryId), "Cleaning Category does not exist.");
            }

            if (!this.service.GetPropertyCategories().Any(m => m.Id == model.PropertyCategoryId))
            {
                this.ModelState.AddModelError(nameof(model.PropertyCategoryId), "Property Category does not exist.");
            }

            if (!this.service.GetFrequencies().Any(m => m.Id == model.FrequencyId))
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

            return RedirectToAction("AddAppoitment", "Appoitment");
        }

    }
}
