﻿namespace SqueegeeLM.Web.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Area("Admin")]
    [Authorize(Roles = "Administrator")]
    public class BaseController : Controller
    {

    }
}