namespace SqueegeeLM.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using SqueegeeLM.Data.Models;
    using SqueegeeLM.Web.Data;
    using SqueegeeLM.Web.Models.Service;

    public class ServiceController : Controller
    {
        private readonly ApplicationDbContext data;

        public ServiceController(ApplicationDbContext data) => this.data = data;

        public IActionResult AddService() => View(new AddServiceViewModel
        {
            CleaningCategories = this.GetCleaningCategories(),
            PropertyCategories = this.GetPropertyCategories(),
            Frequency = this.GetFrequencies()
        });

        [HttpPost]
        public IActionResult AddService(AddServiceViewModel model)
        {
            if (!this.data.CleaningCategories.Any(m => m.Id == model.CleaningCategoryId))
            {
                this.ModelState.AddModelError(nameof(model.CleaningCategoryId), "Cleaning Category does not exist.");
            }

            if (!this.data.PropertyCategories.Any(m => m.Id == model.PropertyCategoryId))
            {
                this.ModelState.AddModelError(nameof(model.PropertyCategoryId), "Property Category does not exist.");
            }

            if (!this.data.Frequencies.Any(m => m.Id == model.FrequencyId))
            {
                this.ModelState.AddModelError(nameof(model.FrequencyId), "Frequency does not exist.");
            }

            if (!ModelState.IsValid)
            {
                model.CleaningCategories = this.GetCleaningCategories();
                model.PropertyCategories = this.GetPropertyCategories();
                model.Frequency = this.GetFrequencies();

                return View(model);
            }

            var service = new Service
            {
                CleaningCategoryId = model.CleaningCategoryId,
                PropertyCategoryId = model.PropertyCategoryId,
                FrequencyId = model.FrequencyId,
            };

            this.data.Services.Add(service);
            this.data.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        private IEnumerable<CleaningCategoryViewModel> GetCleaningCategories() 
            => this.data
                .CleaningCategories
                .Select(c => new CleaningCategoryViewModel
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToList();

        private IEnumerable<PropertyCategoryViewModel> GetPropertyCategories()
           => this.data
               .PropertyCategories
               .Select(c => new PropertyCategoryViewModel
               {
                   Id = c.Id,
                   Name = c.Name
               })
               .ToList();

        private IEnumerable<FrequencyServiceViewModel> GetFrequencies()
           => this.data
               .Frequencies
               .Select(c => new FrequencyServiceViewModel
               {
                   Id = c.Id,
                   Name = c.Name
               })
               .ToList();
    }
}
