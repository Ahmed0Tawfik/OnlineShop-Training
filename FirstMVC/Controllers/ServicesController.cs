﻿using Microsoft.AspNetCore.Mvc;

namespace FirstMVC.Controllers
{
    public class ServicesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
