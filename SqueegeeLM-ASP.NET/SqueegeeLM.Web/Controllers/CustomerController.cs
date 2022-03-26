using Microsoft.AspNetCore.Mvc;

namespace SqueegeeLM.Web.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Create()
        {
            return View();
        }
    }
}
