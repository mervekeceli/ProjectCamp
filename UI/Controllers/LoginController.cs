﻿using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult AdminLogin()
        {
            return View();
        }
    }
}
