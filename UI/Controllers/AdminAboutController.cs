using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    public class AdminAboutController : Controller
    {
        AboutManager aboutManager = new AboutManager(new EfAboutDal());

        public IActionResult Index()
        {
            var aboutValues = aboutManager.GetList();
            return View(aboutValues);
        }

        [HttpGet]
        public IActionResult AddAbout()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddAbout(About about)
        {
            aboutManager.AboutAdd(about);
            return RedirectToAction("Index");
        }
    }
}
