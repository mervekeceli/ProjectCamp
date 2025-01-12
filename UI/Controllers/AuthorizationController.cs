﻿using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    public class AuthorizationController : Controller
    {
        AdminManager adminManager = new AdminManager(new EfAdminDal());
        public IActionResult Index()
        {
            var adminValues = adminManager.GetList();
            return View(adminValues);
        }

        [HttpGet]
        public IActionResult AddAdmin()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddAdmin(Admin admin)
        {
            adminManager.AdminAdd(admin);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditAdmin(int id)
        {
            var adminValue = adminManager.GetById(id);
            return View(adminValue);
        }

        [HttpPost]
        public IActionResult EditAdmin(Admin admin)
        {
            adminManager.AdminUpdate(admin);
            return RedirectToAction("Index");
        }
    }
}