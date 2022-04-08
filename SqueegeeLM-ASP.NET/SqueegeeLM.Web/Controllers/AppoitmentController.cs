namespace SqueegeeLM.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using SqueegeeLM.Services.Contracts;
    using SqueegeeLM.Web.Models.Appoitment;

    public class AppoitmentController : BaseController
    {
        private readonly IAppoitmentService appoitmentService;

        public AppoitmentController(IAppoitmentService appoitmentService)
        {
            this.appoitmentService = appoitmentService;
        }

        public IActionResult Add() => View();

        [HttpPost]
        public IActionResult Add(AppoitmentViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            //var customerServices = this.appoitmentService.GetAllServices();

            //var createAppoitment = this.appoitmentService.AddAppoitment(
            //    model.CustomerId,
            //    model.Date,
            //    model.IsBooked, 
            //    model.Services);

            return View(model);
        }
    }
}
