using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
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
            var defaultList = new DefaultViewModel
            {
                Headings = headingManager.GetList(),
                Contents = contentManager.GetList()
            };
            return PartialView(defaultList);
        }

        public IActionResult Headings()
        {
            var defaultList = new DefaultViewModel
            {
                Headings = headingManager.GetList() ?? new List<Heading>(),
                Contents = contentManager.GetList() ?? new List<Content>()
            };
            return View(defaultList);
        }
    }

    public class DefaultViewModel
    {
        public List<Heading>? Headings { get; set; }
        public List<Content>? Contents { get; set; }
    }
}
