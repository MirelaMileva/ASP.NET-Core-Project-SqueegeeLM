namespace SqueegeeLM.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using SqueegeeLM.Services.Contracts;
    using SqueegeeLM.Web.Models.Appoitment;

    public class AppoitmentController : BaseController
    {
        private readonly IAppoitmentService appoitmentService;
        private readonly IServiceService serviceService;

        public AppoitmentController(IAppoitmentService appoitmentService, IServiceService serviceService)
        {
            this.appoitmentService = appoitmentService;
            this.serviceService = serviceService;
        }

        public IActionResult Add() => View();

        [HttpPost]
        public IActionResult Add(AppoitmentViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var createAppoitment = this.appoitmentService.AddAppoitment(
                model.CustomerId,
                model.Date,
                model.IsBooked);

            return RedirectToAction("AddService", "Service");
        }
    }
}
