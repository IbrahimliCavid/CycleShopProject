﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CycleStore.Web.MVC.Areas.Dashboard.Controllers
{
    public class HomeController : Controller
    {
        [Area("Dashboard")]
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
    }
}
