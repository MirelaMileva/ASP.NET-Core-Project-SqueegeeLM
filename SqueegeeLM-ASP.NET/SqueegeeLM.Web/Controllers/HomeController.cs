namespace SqueegeeLM.Web.Controllers
{
    using System.Diagnostics;
    using Microsoft.AspNetCore.Mvc;
    using SqueegeeLM.Web.Constants;
    using SqueegeeLM.Web.Models;

    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewData[MessageConstant.ErrorMessage] = "Something went wrong!";

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}