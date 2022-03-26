namespace SqueegeeLM.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using SqueegeeLM.Data.Models;
    using SqueegeeLM.Services.Contracts;
    using SqueegeeLM.Web.Models.Service;

    public class ServiceController : Controller
    {
        private readonly IServiceService service;

        public ServiceController(IServiceService service)
        {
            this.service = service;
        }

        [Authorize]
        public IActionResult AddService() => View(new AddServiceViewModel
        {
            CleaningCategories = this.service.GetCleaningCategories(),
            PropertyCategories = this.service.GetPropertyCategories(),
            Frequency = this.service.GetFrequencies()
        });

        [HttpPost]
        [Authorize]
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

            return RedirectToAction("Index", "Home");
        }

    }
}
