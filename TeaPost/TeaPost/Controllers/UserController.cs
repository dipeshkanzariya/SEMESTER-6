﻿using Microsoft.AspNetCore.Mvc;

namespace TeaPost.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}