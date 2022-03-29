namespace SqueegeeLM.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using SqueegeeLM.Web.Models.Appoitment;

    public class AppoitmentController : BaseController
    {
        public IActionResult AddAppoitment()
        {
            return View();
        }

        //[HttpPost]
        //public IActionResult AddAppoitment(AppoitmentViewModel model)
        //{
        //    if (!ModelState.IsValid)
        //    {

        //    }
        //}
    }
}
