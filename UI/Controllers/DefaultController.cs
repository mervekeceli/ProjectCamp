using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    public class DefaultController : Controller
    {
        HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        //GET : Default
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Headings()
        {
            var headingList = headingManager.GetList();
            return View(headingList);
        }
    }
}
