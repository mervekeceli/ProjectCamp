using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        ContentManager contentManager = new ContentManager(new EfContentDal());
        //GET : Default
        public PartialViewResult Index()
        {
            var contentList = contentManager.GetList();
            return PartialView(contentList);
        }

        public IActionResult Headings()
        {
            var headingList = headingManager.GetList();
            return View(headingList);
        }
    }
}
