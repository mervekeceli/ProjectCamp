using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    public class DefaultController : Controller
    {
        HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        ContentManager contentManager = new ContentManager(new EfContentDal());
        //GET : Default
        public PartialViewResult Index()
        {
            var contentList = contentManager.GetList();
            var headingList = headingManager.GetList();
            return PartialView(Tuple.Create(headingList, contentList));
        }

        public IActionResult Headings()
        {
            var contentList = contentManager.GetList();
            var headingList = headingManager.GetList();
            return View(Tuple.Create(headingList, contentList));
        }
    }
}
