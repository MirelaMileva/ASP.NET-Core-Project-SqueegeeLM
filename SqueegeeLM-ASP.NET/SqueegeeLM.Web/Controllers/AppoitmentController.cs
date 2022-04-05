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

            return View(model);
        }

        //public IActionResult UserAppoitments()
        //{

        //}
    }
}
