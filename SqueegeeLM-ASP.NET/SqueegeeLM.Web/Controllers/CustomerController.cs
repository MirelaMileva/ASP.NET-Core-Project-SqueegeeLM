﻿namespace SqueegeeLM.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class CustomerController : Controller
    {
        public IActionResult Create()
        {
            return View();
        }
    }
}
